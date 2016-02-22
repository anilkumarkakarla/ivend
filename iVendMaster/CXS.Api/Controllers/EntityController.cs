using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CXS.Api.Controllers
{
    [Route("iVendAPI/V1.0/[controller]")]
    public class EntityController : Controller
    {
        /// <summary>
        /// This method returns the Entity details
        /// </summary>
        /// <returns>To return Details of Entity Available</returns>
        [HttpGet]
        public string GetEntity()
        {
            return "[  { \"id\": 1, \"name\": \"products\", \"description\": \"Product Entity\", \"url\": \"/iVendAPI/V1.0/Product\"},   { \"id\": 2, \"name\": \"customer\", \"description\": \"customer Entity\", \"url\": \"/api/customers\"}]";
        }

        /// <summary>
        /// This method returns the Entity details by Id
        /// </summary>
        /// <param name="Id">Id of Entity</param>
        /// <returns>To return Details of Entity </returns>
        [HttpGet("{Id}")]
        public string GetEntity(string Id)
        {
            return "[  { \"id\": 1, \"name\": \"products\", \"description\": \"Product Entity\", \"url\": \"/iVendAPI/V1.0/Product\" ,  \"fields\":[{ \"name\": \"productId\", \"type\": \"String\", \"businessName\": \"Prodcut Id\", \"description\": \"Product Id\"}]}]";
        }




  

    }
}
