using System;
using NUnit.Framework;
using System.Collections.Generic;
using CXS.Mpos.Core;

namespace CXS.Mpos.POS.Tests
{
	[TestFixture ()]
	public class ItemServiceTest
	{
		[InjectionRequired]
		private IItemWebService service { get; set; }

		[SetUp]
		public void SetupService ()
		{
			DependencyConfig config = new DependencyConfig ();
			Parameters parameters = new Parameters ();
			config.Define (typeof(IItemWebService), typeof(MockItemWebService));
			DependencyContainer container = new DependencyContainer (config);
			container.ResolveDependencies (this, parameters);
		}

		[Test]
		public void InjectionTest ()
		{
			Assert.True (service.GetType ().Equals (typeof(MockItemWebService)));
		}

		[Test]
		public void GetItemsTest ()
		{
			List<Item> items = service.GetItems ();
			Assert.True (items != null && items.Count > 0); 
		}
	}
}

