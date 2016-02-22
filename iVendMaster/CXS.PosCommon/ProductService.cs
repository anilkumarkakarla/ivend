using CXS.Core.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CXS.Core.Entities;
using Newtonsoft.Json;
using System.Net.Http;

namespace CXS.PosCommon
{
	public class ProductService : Service, IProductRepository
	{
		public const string PRODUCT_BY_ANY = "Product/GetProductByAny?searchField={0}&searchValue={1}";
		public const string PRODUCT_BY_ALL = "Product/GetProductByAll?Product={1}";
		public const string PRODUCT_BY_ID = "Product/GetProductById/{0}";
		public const string PRODUCT_BY_KEY = "Product/GetProductByproductKey/{0}";
		public const string CREATE_PRODUCT = "Product/GetProductById?Id={0}";
		public const string UPDATE_PRODUCT = "Product/GetProductById?Id={0}";
		public const string DELETE_PRODUCT = "Product/GetProductById?Id={0}";

		public ProductService(IAppSettings settings)
			: base(settings)
		{
		}

		public string CreateProduct(InvProduct _objProduct)
		{
			string returnResult = null;

			try
			{
				returnResult = UpdateItem(_objProduct, CREATE_PRODUCT);
			}
			catch
			{
				return null;
			}

			return returnResult;
		}

		public string DeleteProduct(long productKey)
		{
			string returnResult = null;

			try
			{
				//returnResult = PostContent(_objProduct, CREATE_PRODUCT);
			}
			catch
			{
				return null;
			}

			return returnResult;

		}

		public string UpdateProduct(long productKey, InvProduct Product)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<InvProduct> GetProductByAll(InvProduct _objprd)
		{
			IEnumerable<InvProduct> itemList = null;

			try
			{
				using (var client = GetHttpClient())
				{
					var response = client.GetAsync(string.Format(PRODUCT_BY_ALL, _objprd)).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						itemList = JsonConvert.DeserializeObject<IEnumerable<InvProduct>>(result);
					}
				}
			}
			catch
			{
				return null;
			}

			return itemList;
		}

		public IEnumerable<InvProduct> GetProductByAny(string searchField, string searchValue)
		{
			IEnumerable<InvProduct> customerList = null;

			try
			{
				using (var client = GetHttpClient())
				{
					var response = client.GetAsync(this.BaseUri + string.Format(PRODUCT_BY_ANY, searchField, searchValue)).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						customerList = JsonConvert.DeserializeObject<IEnumerable<InvProduct>>(result);
					}
				}
			}
			catch
			{
				return null;
			}

			return customerList;
		}

		public InvProduct GetProductById(string Id)
		{
			InvProduct customer = null;
			try
			{
				using (var client = GetHttpClient())
				{
					var response = client.GetAsync(this.BaseUri + string.Format(PRODUCT_BY_ID, Id)).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						customer = JsonConvert.DeserializeObject<InvProduct>(result);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return customer;
		}

		public IEnumerable<InvProduct> GetProductByproductKey(long productKey)
		{
			IEnumerable<InvProduct> customerList = null;

			try
			{
				using (var client = GetHttpClient())
				{
					var response = client.GetAsync(this.BaseUri + string.Format(PRODUCT_BY_KEY, productKey)).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						customerList = JsonConvert.DeserializeObject<IEnumerable<InvProduct>>(result);
					}
				}
			}
			catch
			{
				return null;
			}

			return customerList;
		}
	}
}
