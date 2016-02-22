using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CXS.Api.Business;
using Microsoft.AspNet.Mvc;
using System.Net;

namespace CXS.Api.BusinessObjects
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly IvendDbContext _dbContext;

        public CustomerRepository(IvendDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IActionResult CreateCustomer(CusCustomer customer)
        {
            try
            {
                _dbContext.Customer.Add(customer);
                _dbContext.SaveChanges();
                return new HttpStatusCodeResult((int)HttpStatusCode.Created);
            }
           catch (Exception exp)
            {
                throw exp;
            }
        }

       public IEnumerable<CusCustomer> GetCustomerByCustomerKey(long CustomerKey)
        {

            var customer = new List<CusCustomer>();
           try
            {
                  customer = (from c in _dbContext.Customer
                             where Convert.ToString(c.CustomerKey).StartsWith(Convert.ToString(CustomerKey))
                              select c).ToList();
                
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return customer;

        }


        public IEnumerable<CusCustomer> GetCustomerByAny(string searchField, string searchValue)
        {
            var customer = new List<CusCustomer>();
            try
            {
                if (searchField == ("CustomerKey"))
                {
                    customer = (from c in _dbContext.Customer
                                where Convert.ToString(c.CustomerKey).StartsWith(searchValue)
                                select c ).ToList();
                }
                else
                {
                    customer = (from c in _dbContext.Customer
                                where (c.FirstName.StartsWith(searchValue)) || (c.LastName.StartsWith(searchValue)) || (c.MiddleName.StartsWith(searchValue))
                                select c).ToList();
               }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return customer;

        }



        public IEnumerable<CusCustomer> GetCustomerByAll(CusCustomer _objcust, string searchOperator)
        {
           var customer = new List<CusCustomer>();
           
           try
            {
                if (searchOperator.ToUpper() == "AND")
                {
                    if (_objcust.CustomerKey != 0 && !string.IsNullOrEmpty(_objcust.FirstName))
                        customer = (from c in _dbContext.Customer
                                    where Convert.ToString(c.CustomerKey).StartsWith(Convert.ToString(_objcust.CustomerKey)) && (c.FirstName.StartsWith(_objcust.FirstName))
                                    select c).ToList();
                }
                else if(searchOperator.ToUpper() == "OR")
                {

                    if (_objcust.CustomerKey != 0 || !string.IsNullOrEmpty(_objcust.FirstName))
                        customer = (from c in _dbContext.Customer
                                    where Convert.ToString(c.CustomerKey).StartsWith(Convert.ToString(_objcust.CustomerKey)) || (c.FirstName.StartsWith(_objcust.FirstName))
                                    select c).ToList();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

          return customer;

        }


        public CusCustomer GetCustomerById(string Id)
        {
            CusCustomer customer = new CusCustomer();
            try
            {
                customer = _dbContext.Customer.Where(c => c.Id == Id).FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            return customer;
        }

     public IActionResult UpdateCustomer(long custKey, CusCustomer customer)
        {
            try
            {
                var cust = _dbContext.Customer.Where(p => p.CustomerKey == custKey).First();
                if (cust != null)
                {
                    cust.FirstName = customer.FirstName;
                    cust.LastName = customer.LastName;
                    cust.Created = customer.Created;
                    cust.CreatedBy = customer.CreatedBy;
                    cust.Modified = customer.Modified;
                    cust.ModifiedBy = customer.ModifiedBy;
                    _dbContext.SaveChanges();
                 }
                return new HttpStatusCodeResult((int)HttpStatusCode.OK);

            }
           catch (Exception exp)
            {
                throw exp;
            }
        }

        public IActionResult DeleteCustomer(long custKey)
        {
          try
            {
                var cust = _dbContext.Customer.Where(p => p.CustomerKey == custKey).First();

                if (cust != null)
                {
                    cust.IsDeleted = true;
                 if((_dbContext.SaveChanges() > 0))
                    {
                        var ArrAccounts = from c in _dbContext.ArrAccountsReceivable
                                          where c.CustomerKey == custKey
                                          select c;
                        if (ArrAccounts != null)
                        {
                            foreach (var account in ArrAccounts)
                            {
                                account.IsDeleted = true;
                            }
                            _dbContext.SaveChanges();
                        }
                    }

                }
              
                return new HttpStatusCodeResult((int)HttpStatusCode.NoContent);
            }
          catch (Exception exp)
            {
                throw exp;
            }

        }




    }
}
