using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CXS.Core.Entities;

namespace CXS.Core.Framework.Data
{
   public interface IPurchaseOrderRepository : IRepository<PurPurchaseOrder>
    {
        string CreatePurchaseOrderDetails(PurPurchaseOrder _objPurchaseOrder);

        string UpdatePurchaseOrderDetails(long purchaseOrderKey, PurPurchaseOrder _objPurchaseOrder);

        IEnumerable<PurPurchaseOrder> GetPurchaseOrderByAll(PurPurchaseOrder _objpur);


        string DeletePurchaseOrderDetails(long purchaseOrderKey);

        IEnumerable<PurPurchaseOrder> GetPurchaseOrderByAny(string searchField, string searchValue);

        IEnumerable<PurPurchaseOrder> GetPurchaseOrderDetailsByVendorName(string venderName);
    }
}
