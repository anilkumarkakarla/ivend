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
    public class SalesController : Controller
    {
        [FromServices]
        public ISalesRepository _repository { get; set; }

        /// <summary>
        ///Create a new Sales
        /// </summary>
        /// <param name="trxTransaction">trxTransaction object is required to create a Sales</param>
        /// <returns>201</returns>
        [Route("CreateaNewSale")]
        [HttpPost]
        public IActionResult CreateSaleTransaction([FromBody]TrxTransaction trxTransaction)
        {
            if (ModelState.IsValid)
            {
                var result = _repository.CreateSaleTransaction(trxTransaction);
                return result;
            }
            else
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }
    }
}
