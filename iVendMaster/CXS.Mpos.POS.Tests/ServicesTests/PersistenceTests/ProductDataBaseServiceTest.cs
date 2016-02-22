using System;
using NUnit.Framework;
using System.Collections.Generic;
using CXS.Mpos.Core;

namespace CXS.Mpos.POS.Tests
{
	[TestFixture ()]
	public class ProductDataBaseServiceTest
	{
		[InjectionRequired]
		private IProductDataBaseService service { get; set; }

		[SetUp]
		public void BeforeTests ()
		{
			string DataBasePath = System.IO.Path.Combine (Environment.CurrentDirectory, "database.db");
			DataBaseService dbService = new DataBaseService (DataBasePath);
			dbService.Initialize ("dbDemo");

			DependencyConfig config = new DependencyConfig ();
			Parameters parameters = new Parameters ();
			config.Define (typeof(IProductDataBaseService), typeof(MockProductDataBaseService));
			DependencyContainer container = new DependencyContainer (config);
			container.ResolveDependencies (this, parameters);

			service.DBService = dbService;
		}

		[Test()]
		public void InjectionTest() {
			Assert.True (service.GetType ().Equals (typeof(MockProductDataBaseService)));
		}

		[Test ()]
		public void GetCustomers() 
		{
			List<Product> result = new List<Product> ();
			result = service.GetProducts ("group", "Apparel");
			Assert.True (result.Count != 0);
		}

		[Test ()]
		public void Search() 
		{
			List<Product> result = new List<Product> ();
			result = service.SearchProductsWithParameters ("category", "All", "100103");
			Assert.True (result.Count != 0);
		}
	}
}

