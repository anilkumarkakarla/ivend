using System;
using System.Collections.Generic;

namespace CXS.Mpos.Core
{

	public class OperationGroup
	{
		public OperationGroup ()
		{
			_operations = new List<OperationContainer> ();
			Credentials = new List<string> ();
		}

		public class OperationContainer
		{
			public Type OperationType;
			public Parameters Parameters;
			public Action<Parameters> CompleteHandler;
			public Action<Exception> ErrorHandler;
		}

		private List<OperationContainer> _operations;

		public List<OperationContainer> Operations {
			get {
				return _operations;
			}
		}

		public List<string> Credentials;
		public Action<Parameters> CompleteHandler;
		public Action<Exception> ErrorHandler;

		public void AddOperation (Type operationType, Parameters parameters = null, Action<Parameters> completeHandler = null, Action<Exception> errorHandler = null)
		{
			var operationContainer = CreateOperationContainer (operationType, parameters, completeHandler, errorHandler);
			_operations.Add (operationContainer);
		}

		public void AddOperationToStart (Type operationType, Parameters parameters = null, Action<Parameters> completeHandler = null, Action<Exception> errorHandler = null)
		{
			var operationContainer = CreateOperationContainer (operationType, parameters, completeHandler, errorHandler);
			_operations.Insert (0, operationContainer);
		}

		private OperationContainer CreateOperationContainer (Type operationType, Parameters parameters, Action<Parameters> completeHandler, Action<Exception> errorHandler)
		{
			var operationContainer = new OperationContainer ();
			operationContainer.OperationType = operationType;
			operationContainer.Parameters = parameters;
			operationContainer.CompleteHandler = completeHandler;
			operationContainer.ErrorHandler = errorHandler;
			return operationContainer;
		}
	}
}

