using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CXS.Api.Business;
using Microsoft.AspNet.Mvc;

namespace CXS.Api.BusinessObjects
{
   public interface IPurchaseOrderRepository
    {
        IActionResult CreatePurchaseOrderDetails(PurPurchaseOrder _objPurchaseOrder);

        IActionResult UpdatePurchaseOrderDetails(long purchaseOrderKey, PurPurchaseOrder _objPurchaseOrder);

        IEnumerable<PurPurchaseOrder> GetPurchaseOrderByAll(PurPurchaseOrder _objpur, string searchOperator);


        IActionResult DeletePurchaseOrderDetails(long purchaseOrderKey);

        IEnumerable<PurPurchaseOrder> GetPurchaseOrderByAny(string searchField, string searchValue);

        IEnumerable<PurPurchaseOrder> GetPurchaseOrderDetailsByVendorName(string venderName);


    }
}
