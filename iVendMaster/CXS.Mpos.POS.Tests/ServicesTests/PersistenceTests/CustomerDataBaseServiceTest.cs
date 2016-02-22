using System;
using NUnit.Framework;
using System.Collections.Generic;
using CXS.Mpos.Core;

namespace CXS.Mpos.POS.Tests
{
	[TestFixture ()]
	public class CustomerDataBaseServiceTest
	{
		[InjectionRequired]
		private ICustomerDataBaseService service { get; set; }

		[SetUp]
		public void BeforeTests ()
		{
			string DataBasePath = System.IO.Path.Combine (Environment.CurrentDirectory, "database.db");
			DataBaseService dbService = new DataBaseService (DataBasePath);
			dbService.Initialize ("dbDemo");

			DependencyConfig config = new DependencyConfig ();
			Parameters parameters = new Parameters ();
			config.Define (typeof(ICustomerDataBaseService), typeof(MockCustomerDataBaseService));
			DependencyContainer container = new DependencyContainer (config);
			container.ResolveDependencies (this, parameters);

			service.DBService = dbService;
		}

		[Test()]
		public void InjectionTest() {
			Assert.True (service.GetType ().Equals (typeof(MockCustomerDataBaseService)));
		}

		[Test ()]
		public void GetCustomers() 
		{
			List<Customer> result = new List<Customer> ();
			result = service.GetCustomers ("Customers");
			Assert.True (result.Count != 0);
		}

		[Test ()]
		public void Search() 
		{
			List<Customer> result = new List<Customer> ();
			result = service.SearchCustomersWithParameters ("Customers", "C0001");
			Assert.True (result.Count != 0);
		}
	}
}

