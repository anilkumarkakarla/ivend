using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Reflection;

namespace CXS.Mpos.Core
{
	public class OperationProcessor
	{
		private class GroupContainer
		{
			public OperationGroup Group;
			public Parameters Parameters;
		}

		private static OperationProcessor instance;

		private Queue<GroupContainer> MainQueue;
		private ManualResetEvent LockEvent;
		private object SetLock = new object ();

		public DependencyContainer DepedencyContainer;

		public static OperationProcessor Instance {
			get {
				if (instance == null) {
					instance = new OperationProcessor ();
					instance.Initialize ();
				}
				return instance;
			}
		}

		private OperationProcessor ()
		{
			MainQueue = new Queue<GroupContainer> ();
			DepedencyContainer = new DependencyContainer ();
		}

		#region Public Interface

		public void PerformGroup (OperationGroup group, Parameters parameters, Action<Parameters> completeHandler = null, Action<Exception> errorHandler = null)
		{
			group.CompleteHandler = completeHandler;
			group.ErrorHandler = errorHandler;
			AddGroupToQueue (group, parameters);
		}

		public void PerformOperation (Type operationType, Parameters parameters, Action<Parameters> completeHandler = null, Action<Exception> errorHandler = null)
		{
			var group = new OperationGroup ();
			group.AddOperation (operationType, parameters);
			PerformGroup (group, null, completeHandler, errorHandler);
		}

		public void Initialize ()
		{
			LockEvent = new ManualResetEvent (false);
			Task.Factory.StartNew (() => {
				while (true) {
					LockEvent.WaitOne ();
					lock (SetLock) {
						if (MainQueue.Count > 0) {
							OperationTick ();	
						} else {
							LockEvent.Reset ();
						}
					}
				}
			}, TaskCreationOptions.LongRunning);
		}

		#endregion

		#region Operation Queue Execution

		private void AddGroupToQueue (OperationGroup group, Parameters parameters)
		{
			if (group.Credentials != null && group.Credentials.Count > 0) {
				var credentials = new Parameters ();
				credentials.Add ("Credentials", group.Credentials);
				group.AddOperationToStart (typeof(SecurityOperation), credentials);
			}

			var groupContainer = new GroupContainer ();
			groupContainer.Group = group;
			groupContainer.Parameters = parameters;
			lock (SetLock) {
				MainQueue.Enqueue (groupContainer);
				LockEvent.Set ();
			}
		}

		private void ExecuteGroup (OperationGroup group, Parameters parameters)
		{
			Parameters groupResults = new Parameters ();

			foreach (var operationContainer in group.Operations) {
				Operation operation = (Operation)Activator.CreateInstance (operationContainer.OperationType);
				try {
					groupResults.AddParameters (operationContainer.Parameters);
					DepedencyContainer.ResolveDependencies (operation, groupResults);

					operation.Execute ();

					Parameters results = operation.Result;
					groupResults.AddParameters (results);
					if (operationContainer.CompleteHandler != null) {
						operationContainer.CompleteHandler (results);
					}
				} catch (Exception e) {
					if (operationContainer.ErrorHandler != null) {
						operationContainer.ErrorHandler (e);
					}
					if (group.ErrorHandler != null) {
						group.ErrorHandler (e);
					}
					return;
				}
			}

			if (group.CompleteHandler != null) {
				group.CompleteHandler (groupResults);
			}
		}

		private void OperationTick ()
		{
			GroupContainer groupContainer = null;
			try {
				groupContainer = MainQueue.Dequeue ();
			} catch (InvalidOperationException e) {
				groupContainer = null;
			}
			if (groupContainer != null) {
				ExecuteGroup (groupContainer.Group, groupContainer.Parameters);
			}
		}

		#endregion
	}
}

