using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CXS.Api.Business;
using CXS.Api.BusinessObjects;
using System.Net;

namespace CXS.Api.Controllers
{
    [Route("iVendAPI/V1.0/[controller]")]
    public class CustomerController : Controller
    {
        [FromServices]
        public ICustomerRepository _repository { get; set; }

        /// <summary>
        /// This method returns the Customer Details
        /// </summary>
        /// <param name="Id">Id of Customer</param>
        /// <returns>To return Details of Customer</returns>
        /// <remarks>Please Provide the Id of Customer</remarks>
        [HttpGet("GetCustomerByID/{Id}")]
        public CusCustomer GetCustomerById(string Id)
        {
            var customerDetails = _repository.GetCustomerById(Id);
            return customerDetails;
         }

        /// <summary>
        /// This method returns the List of Customers 
        /// </summary>
        /// <param name="CustomerKey">CustomerKey of Customer</param>
        /// <returns>To return List of Customers Available</returns>
        /// <remarks>Please Provide the CustomerKey</remarks>
        [HttpGet("GetCustomerBycustomerKey/{CustomerKey:long}")]
        public IEnumerable<CusCustomer> GetCustomersByCustomerKey(long CustomerKey)
        {
            var customerDetails = _repository.GetCustomerByCustomerKey(CustomerKey);
            return customerDetails;
        }

        /// <summary>
        /// This method returns the List of Customers 
        /// </summary>
        /// <param name="searchField">SearchField is field name of Customer</param>
        /// <param name="searchValue">SearchValue is the field value of  Customer</param>
        /// <returns>To return List of Customers Available</returns>
        [HttpGet]
        [Route("GetCustomerByAny")]
       public IEnumerable<CusCustomer> GetCustomerDetailsByAny([FromQuery] string searchField, [FromQuery]string searchValue)
        {
            var customerDetails = _repository.GetCustomerByAny(searchField, searchValue);
            return customerDetails;

        }

        /// <summary>
        /// This method returns the List of Customers 
        /// </summary>
        /// <param name="customer">Customer object is required to return list of Customers</param>
        /// <param name="searchOperator">searchOperator is the required for search based on search operator provided e.g.(either AND or  OR) </param>
        /// <returns>To return List of Customers Available</returns>
        [HttpPost("GetCustomerByAll/{searchOperator}")]
        public IEnumerable<CusCustomer> GetCustomerDetailsByAll(string searchOperator, [FromBody]CusCustomer customer)
        {
            var customerDetails = _repository.GetCustomerByAll(customer, searchOperator);
            return customerDetails;
        }

        /// <summary>
        ///Create a new customer
        /// </summary>
        /// <param name="customer">Customer object is required to create a Customer</param>
        /// <returns>201</returns>
        [Route("CreateaNewCustomer")]
        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CusCustomer customer)
        {
            if (ModelState.IsValid)
            {
                var result = _repository.CreateCustomer(customer);
                return result;
            }
            else
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        ///Update an existing customer
        /// </summary>
        /// <param name="customerKey">CustomerKey is required to update an existing customer</param>
        /// <param name="customer">Customer object  is required to update a Customer</param>
        /// <returns>200</returns>
        [Route("UpdateCustomer/{customerKey:long}")]
        [HttpPut]
        public IActionResult UpdateCustomerDetails(long customerKey, [FromBody]CusCustomer customer)
        {
            if (ModelState.IsValid)
            {
                var result = _repository.UpdateCustomer(customerKey, customer);
                return result;
            }
            else
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

        }

        /// <summary>
        ///Delete a customer
        /// </summary>
        /// <param name="customerKey">CustomerKey is required to delete an existing customer</param>
        /// <returns>204</returns>
        [HttpDelete("DeleteCustomer/{customerKey:long}")]
        public IActionResult DeleteCustomerDetails(long customerKey)
        {
            _repository.DeleteCustomer(customerKey);
            return new HttpStatusCodeResult((int)HttpStatusCode.NoContent);

        }



    }
}
