using System;
using CXS.Mpos.Core;
using NUnit.Framework;
using System.Threading;

namespace CXS.Mpos.Core.Tests
{
	[TestFixture ()]
	public class DITests
	{
		[Test ()]
		public void ResolveDependenciesTest ()
		{
			Parameters param = new Parameters ();
			param.Add ("StringProperty1", "Hello");
			param.Add ("StringProperty2", "Hello again");
			var obj = new DITestClass ();
			DependencyContainer container = new DependencyContainer ();
			container.ResolveDependencies (obj, param);

			Assert.True (obj.StringProperty.Equals ("Hello"));
			Assert.True (obj.StringProperty2.Equals ("Hello again"));
			Assert.True (obj.StringProperty3 == null);
		}

		[Test ()]
		public void ResolveDependenciesInOperationsTest ()
		{
			var op = OperationProcessor.Instance;

			var groupExpectation = new AutoResetEvent (false);

			OperationGroup group = new OperationGroup ();
			group.AddOperation (typeof(DependenciesOptionalOperation));
			group.AddOperation (typeof(DependenciesRequiredOperation));

			op.PerformGroup (group, null, (Parameters results) => {
				if (results.ContainsKey ("Count")) {
					var value = results ["Count"];
					if (value.Equals ("2")) {
						groupExpectation.Set ();
					}
				}
			});
				
			Assert.True (groupExpectation.WaitOne (TimeSpan.FromSeconds (10)));
		}

		[Test ()]
		public void ResolveDependenciesInOperationsErrorTest ()
		{
			var op = OperationProcessor.Instance;
			op.Initialize ();

			var groupExpectation = new AutoResetEvent (false);

			OperationGroup group = new OperationGroup ();

			group.AddOperation (typeof(DependenciesRequiredOperation));

			op.PerformGroup (group, null, null, (Exception e) => {
				if (e != null) {
					groupExpectation.Set ();
				}
			});

			Assert.True (groupExpectation.WaitOne (TimeSpan.FromSeconds (10)));
		}

		[Test()]
		public void DependencyContainerTest()
		{
			DependencyConfig config = new DependencyConfig ();
			Parameters parameters = new Parameters ();
			parameters.Add("StringProperty2", "Test");
			config.Define (typeof(DITestInterface), typeof(DITestInterfaceImpl));
			DependencyContainer container = new DependencyContainer (config);
			var obj = new DITestClass ();
			container.ResolveDependencies (obj, parameters);

			Assert.True (obj.StringProperty2.Equals ("Test"));
			Assert.True (obj.InterfaceProperty.GetType ().Equals (typeof(DITestInterfaceImpl)));
		}
	}
}