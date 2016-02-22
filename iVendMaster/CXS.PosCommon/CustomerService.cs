using System.Collections.Generic;
using CXS.Core.Entities;
using Newtonsoft.Json;
using CXS.Core.Framework.Data;
using System;

namespace CXS.PosCommon
{
	public class CustomerService : Service, ICustomerRepository
	{
		public const string CUSTOMER_BY_ANY = "Customer/GetCustomerByAny?searchField={0}&searchValue={1}";
		public const string CUSTOMER_BY_ALL = "Customer/GetCustomerByAny?searchField={0}&searchValue={1}";
		public const string CUSTOMER_BY_KEY = "Customer/GetCustomerBycustomerKey/{0}";
		public const string CUSTOMER_BY_ID = "Customer/GetCustomerById/{0}";

		public CustomerService(IAppSettings settings)
			: base(settings)
		{

		}

		public string CreateCustomer(CusCustomer customer)
		{
			throw new NotImplementedException();
		}

		public string DeleteCustomer(long custKey)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CusCustomer> GetCustomerByAll(CusCustomer _objcust)
		{
			IEnumerable<CusCustomer> customerList = null;

			try
			{
				using (var client = GetHttpClient())
				{
					var response = client.GetAsync(this.BaseUri + string.Format(CUSTOMER_BY_ALL, _objcust)).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						customerList = JsonConvert.DeserializeObject<IEnumerable<CusCustomer>>(result);
					}
				}
			}
			catch
			{
				return null;
			}

			return customerList;
		}

		public IEnumerable<CusCustomer> GetCustomerByAny(string searchField, string searchValue)
		{
			IEnumerable<CusCustomer> customerList = null;

			try
			{
				using (var client = GetHttpClient())
				{
					var response = client.GetAsync(this.BaseUri + string.Format(CUSTOMER_BY_ANY, searchField, searchValue)).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						customerList = JsonConvert.DeserializeObject<IEnumerable<CusCustomer>>(result);
					}
				}
			}
			catch
			{
				return null;
			}

			return customerList;
		}

		public IEnumerable<CusCustomer> GetCustomerByCustomerKey(long CustomerKey)
		{
			IEnumerable<CusCustomer> customerList = null;

			try
			{
				using (var client = GetHttpClient())
				{
					var response = client.GetAsync(this.BaseUri + string.Format(CUSTOMER_BY_KEY, CustomerKey)).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						customerList = JsonConvert.DeserializeObject<IEnumerable<CusCustomer>>(result);
					}
				}
			}
			catch(Exception ex)
			{
				return null;
			}

			return customerList;
		}

		public CusCustomer GetCustomerById(string Id)
		{
			CusCustomer customer = null;
			try
			{
				using (var client = GetHttpClient())
				{
					var response = client.GetAsync(this.BaseUri + string.Format(CUSTOMER_BY_ID, Id)).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						customer = JsonConvert.DeserializeObject<CusCustomer>(result);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return customer;
		}

		public string UpdateCustomer(long custKey, CusCustomer customer)
		{
			throw new NotImplementedException();
		}
	}
}
