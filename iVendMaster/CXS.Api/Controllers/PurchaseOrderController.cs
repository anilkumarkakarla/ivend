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
    public class PurchaseOrderController : Controller
    {
        [FromServices]
        public IPurchaseOrderRepository _repository { get; set; }

        /// <summary>
        /// This method returns  PurPurchaseOrder With Purchase order details collection
        /// </summary>
        /// <param name="venderName">venderName in the PurPurchaseOrder</param>
        /// <returns>To return PurPurchaseOrder With Purchase order details collection Available</returns>
        [Route("GetPuchaseOrderByVendorName/{venderName}")]
        [HttpGet]
        public IEnumerable<PurPurchaseOrder> GetPurchaseOrderByVendor(string venderName)
        {
            var purchaseOrderDetails = _repository.GetPurchaseOrderDetailsByVendorName(venderName);
            return purchaseOrderDetails.ToList();
        }

        /// <summary>
        /// This method returns  PurPurchaseOrder With Purchase order details collection
        /// </summary>
        /// <param name="searchField">SearchField is field name in the PurPurchaseOrder</param>
        /// <param name="searchValue">SearchValue is the field value in the PurPurchaseOrder</param>
        /// <returns>To return PurPurchaseOrder With Purchase order details collection Available</returns>
        [HttpGet]
        [Route("GetPuchaseOrderByAny")]
        public IEnumerable<PurPurchaseOrder> GetPurchaseOrderDetailsByAny([FromQuery]string searchField, [FromQuery]string searchValue)
        {

            var purchaseOrderDetails = _repository.GetPurchaseOrderByAny(searchField, searchValue);
            return purchaseOrderDetails.ToList();

        }


        /// <summary>
        ///This method returns  PurPurchaseOrder With Purchase order details collection 
        /// </summary>
        /// <param name="purchaseOrder">purchaseOrder object is required to return PurPurchaseOrder With Purchase order details collection</param>
        /// <param name="searchOperator">searchOperator is the required for search based on search operator provided e.g.(either AND or  OR) </param>
        /// <returns>To return PurPurchaseOrder With Purchase order details collection Available</returns>
        [HttpPost("GetPuchaseOrderByAll/{searchOperator}")]
        public IEnumerable<PurPurchaseOrder> GetPurchaseOrderDetailsByAll(string searchOperator, [FromBody]PurPurchaseOrder purchaseOrder)
        {
            var purchaseOrderDetails = _repository.GetPurchaseOrderByAll(purchaseOrder, searchOperator);
            return purchaseOrderDetails.ToList();
        }


        /// <summary>
        ///Create a new PurchaseOrder
        /// </summary>
        /// <param name="PurchaseOrder">PurchaseOrder object is required to create a PurchaseOrder</param>
        /// <returns>201</returns>
        [Route("CreateaNewPurchaseOrder")]
        [HttpPost]
        public IActionResult CreatePurchaseOrderDetails([FromBody]PurPurchaseOrder PurchaseOrder)
        {
           if (ModelState.IsValid)
            {
                var result= _repository.CreatePurchaseOrderDetails(PurchaseOrder);
                return result;
            }
            else
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        ///Update an existing PurchaseOrder
        /// </summary>
        /// <param name="purchaseOrderKey">purchaseOrderKey is required to update an existing PurchaseOrder</param>
        /// <param name="purchaseOrder">purchaseOrder object  is required to update a PurchaseOrder</param>
        /// <returns>200</returns>
        [Route("UpdatePurchaseOrder/{purchaseOrderKey:long}")]
        [HttpPut]
        public IActionResult UpdatePurchaseOrderDetails(long purchaseOrderKey,[FromBody]PurPurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                var result = _repository.UpdatePurchaseOrderDetails(purchaseOrderKey, purchaseOrder);
                return result;
            }
            else
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }




        /// <summary>
        ///Delete a PurchaseOrder
        /// </summary>
        /// <param name="purchaseOrderKey">purchaseOrderKey is required to delete an existing PurchaseOrder</param>
        /// <returns>204</returns>
        [HttpDelete("DeletePurchaseOrder/{purchaseOrderKey:long}")]
        public IActionResult DeletePurchaseOrderDetails(long purchaseOrderKey)
        {
           _repository.DeletePurchaseOrderDetails(purchaseOrderKey);
            return new HttpStatusCodeResult((int)HttpStatusCode.NoContent);


        }

    }
}
