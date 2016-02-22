using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CXS.Api.Business;
using Microsoft.AspNet.Mvc;

namespace CXS.Api.BusinessObjects
{
    public interface ICustomerRepository
    {
        IActionResult CreateCustomer(CusCustomer customer);


        IEnumerable<CusCustomer> GetCustomerByAll(CusCustomer _objcust, string searchOperator);


        IEnumerable<CusCustomer> GetCustomerByAny(string searchField, string searchValue);


         IEnumerable<CusCustomer> GetCustomerByCustomerKey(long CustomerKey);

        


        IActionResult UpdateCustomer(long custKey, CusCustomer customer);

        IActionResult DeleteCustomer(long custKey);


        CusCustomer GetCustomerById(string Id);



    }
}
