using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;


namespace CXS.Api.Controllers
{
    [Route("iVendAPI/V1.0/[controller]")]
    public class NavigationController : Controller
    {
        /// <summary>
        /// This method returns the Navigations details
        /// </summary>
        /// <returns>To return Details of Navigations Available</returns>
        [HttpGet]
        public string GetProduct()
        {

            return "[  { \"id\": null, \"order\": 10, \"name\": \"System Init...[  { \"id\": null, \"order\": 10, \"name\": \"System Initialization\", \"description\": null, \"children\": [   {  \"id\": \"1\",  \"order\": 10,  \"name\": \"Enterprise Settings\",  \"description\": null,  \"children\": null   },   {  \"id\": \"2\",  \"order\": 20,  \"name\": \"Communication Settings\",  \"description\": null,  \"children\": null   },   {  \"id\": \"3\",  \"order\": 30,  \"name\": \"System Display Settings\",  \"description\": null,  \"children\": null   },   {  \"id\": \"4\",  \"order\": 40,  \"name\": \"Country\",  \"description\": null,  \"children\": null   },   {  \"id\": \"5\",  \"order\": 50,  \"name\": \"State\",  \"description\": null,  \"children\": null   },   {  \"id\": \"6\",  \"order\": 60,  \"name\": \"Zip Code\",  \"description\": null,  \"children\": null   },   {  \"id\": \"7\",  \"order\": 70,  \"name\": \"Message\",  \"description\": null,  \"children\": null   } ]  },  { \"id\": null, \"order\": 20, \"name\": \"Retail Configuration\", \"description\": null, \"children\": [   {  \"id\": \"1\",  \"order\": 10,  \"name\": \"Hardware Registration\",  \"description\": null,  \"children\": null   } ]  },  { \"id\": null, \"order\": 30, \"name\": \"Test\", \"description\": null, \"children\": [   {  \"id\": \"1\",  \"order\": 10,  \"name\": \"Customer Test\",  \"description\": null,  \"children\": null   } ]  }] ";
        }


    }
}
