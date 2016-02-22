using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CXS.Core.Entities;
using CXS.Core.Framework.Data;

namespace CXS.Core.Framework.Data
{
	public interface ICustomerRepository : IRepository<CusCustomer>
	{
		string CreateCustomer(CusCustomer customer);

		IEnumerable<CusCustomer> GetCustomerByAll(CusCustomer _objcust);

		IEnumerable<CusCustomer> GetCustomerByAny(string searchField, string searchValue);

		IEnumerable<CusCustomer> GetCustomerByCustomerKey(long CustomerKey);

		string UpdateCustomer(long custKey, CusCustomer customer);

		string DeleteCustomer(long custKey);

		CusCustomer GetCustomerById(string Id);
	}
}
