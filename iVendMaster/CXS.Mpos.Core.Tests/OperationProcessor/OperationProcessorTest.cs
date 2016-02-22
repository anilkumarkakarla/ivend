using NUnit.Framework;
using System;
using System.Threading;
using CXS.Mpos.Core;

namespace CXS.Mpos.Core.Tests
{
	[TestFixture ()]
	public class OperationProcessorTest
	{
		[Test ()]
		public void InitializeTest ()
		{
			//TODO: Add DependencyInjector
			var op = OperationProcessor.Instance;
			Assert.Pass ();
		}

		[Test ()]
		public void AddOperationErrorTest ()
		{
			var op = OperationProcessor.Instance;

			var operationExpectation = new AutoResetEvent (false);

			op.PerformOperation (typeof(ErrorOperation), null, null, (Exception e) => operationExpectation.Set ());

			Assert.True (operationExpectation.WaitOne (TimeSpan.FromSeconds (10))); 
		}

		[Test ()]
		public void AddOperationSuccessTest ()
		{
			var op = OperationProcessor.Instance;

			var operationExpectation = new AutoResetEvent (false);

			op.PerformOperation (typeof(FirstOperation), null, (Parameters parameters) => {
				if (parameters.ContainsKey ("1")) {
					operationExpectation.Set ();
				}
			}, null);

			Assert.True (operationExpectation.WaitOne (TimeSpan.FromSeconds (10))); 
		}

		[Test ()]
		public void AddGroupTest ()
		{
			var op = OperationProcessor.Instance;

			var groupExpectation = new AutoResetEvent (false);
			var firstOperationExpectation = new AutoResetEvent (false);
			var secondOperationExpectation = new AutoResetEvent (false);

			OperationGroup group = new OperationGroup ();
			group.AddOperation (typeof(FirstOperation), null, (Parameters result) => {
				if (result.ContainsKey ("1")) {
					firstOperationExpectation.Set ();
				}
			}, null);
			group.AddOperation (typeof(SecondOperation), null, (Parameters result) => {
				if (result.ContainsKey ("2")) {
					secondOperationExpectation.Set ();
				}
			}, null);

			op.PerformGroup (group, null, (Parameters results) => {
				if (results.ContainsKey ("1") && results.ContainsKey ("2")) {
					groupExpectation.Set ();
				}
			});
				
			Assert.True (firstOperationExpectation.WaitOne (TimeSpan.FromSeconds (10)));
			Assert.True (secondOperationExpectation.WaitOne (TimeSpan.FromSeconds (10)));
			Assert.True (groupExpectation.WaitOne (TimeSpan.FromSeconds (10)));
		}

		[Test ()]
		public void GroupCredentials3CheckTest ()
		{
			var op = OperationProcessor.Instance;

			var groupExpectation = new AutoResetEvent (false);
			var firstOperationExpectation = new AutoResetEvent (false);
			var userOperationExpectation = new AutoResetEvent (false);

			op.PerformOperation (typeof(LoadUserOperation), null, (Parameters result) => {
				userOperationExpectation.Set ();
			});


			OperationGroup group = new OperationGroup ();
			group.Credentials.Add ("RUN_OPERATION");

			group.AddOperation (typeof(FirstOperation), null, (Parameters result) => {
				if (result.ContainsKey ("1")) {
					firstOperationExpectation.Set ();
				}
			}, null);

			op.PerformGroup (group, null, (Parameters results) => {
				if (results.ContainsKey ("1")) {
					groupExpectation.Set ();
				}
			});

			Assert.True (userOperationExpectation.WaitOne (TimeSpan.FromSeconds (10)));
			Assert.True (firstOperationExpectation.WaitOne (TimeSpan.FromSeconds (10)));
			Assert.True (groupExpectation.WaitOne (TimeSpan.FromSeconds (10)));
		}

		[Test ()]
		public void GroupCredentials2CheckErrorTest ()
		{
			var op = OperationProcessor.Instance;

			var groupExpectation = new AutoResetEvent (false);
			var userOperationExpectation = new AutoResetEvent (false);

			op.PerformOperation (typeof(LoadUserOperation), null, (Parameters result) => {
				userOperationExpectation.Set ();
			});


			OperationGroup group = new OperationGroup ();
			group.Credentials.Add ("EXCLUSIVE_RIGHTS");

			group.AddOperation (typeof(FirstOperation));

			op.PerformGroup (group, null, null, (Exception e) => {
				if (e.GetType ().Equals (typeof(UnauthorizedAccessException))) {
					groupExpectation.Set ();
				}
			});

			Assert.True (userOperationExpectation.WaitOne (TimeSpan.FromSeconds (10)));
			Assert.True (groupExpectation.WaitOne (TimeSpan.FromSeconds (10)));
		}

		[Test ()]
		public void GroupCredentials1UserNotFoundTest ()
		{
			var op = OperationProcessor.Instance;

			var groupExpectation = new AutoResetEvent (false);

			OperationGroup group = new OperationGroup ();
			group.Credentials.Add ("EXCLUSIVE_RIGHTS");

			group.AddOperation (typeof(FirstOperation));

			op.PerformGroup (group, null, null, (Exception e) => {
				if (e.GetType ().Equals (typeof(UnauthorizedAccessException))) {
					groupExpectation.Set ();
				}
			});
				
			Assert.True (groupExpectation.WaitOne (TimeSpan.FromSeconds (10)));
		}
	}
}

