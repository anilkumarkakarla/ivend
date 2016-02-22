using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CXS.PosCommon;

namespace ConsoleApplication2
{
	class Program
	{
		static void Main(string[] args)
		{
			Settings settings = new Settings();
			CustomerService cs = new CustomerService(settings);
			var cus = cs.GetCustomerById("C0001");
			var cus1 = cs.GetCustomerByCustomerKey(10000000000001);
			var cus2 = cs.GetCustomerByAny("CustomerKey", "10000000000001");

			ProductService ps = new ProductService(settings);
			var p1 = ps.GetProductById("101102");
			var p2 = ps.GetProductByproductKey(1000000000100);
			var p3 = ps.GetProductByAny("productKey", "1000000000100");
		}
	}

	class Settings : IAppSettings
	{
		string webUrl = "http://localhost:58158/iVendAPI/V1.0/";
		public string WebApiUrl
		{
			get
			{
				return webUrl;
			}

			set
			{
				webUrl = value;
			}
		}
	}
}
