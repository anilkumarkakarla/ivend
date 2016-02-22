using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CXS.Core.Entities
{
    public class PurPurchaseOrder
    {

        public PurPurchaseOrder()
        {
            this.PurPurchaseOrderDetail = new HashSet<PurPurchaseOrderDetail>();
        }
        public long PurchaseOrderKey { get; set; }
        public string AccountingId { get; set; }
        public int SiteId { get; set; }
        public long TaxCodeKey { get; set; }
        public long VendorKey { get; set; }
        public string VendorName { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalTaxableAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal SurchargesTotal { get; set; }
        public decimal Total { get; set; }
        public string PurchaseOrderId { get; set; }
        public int Status { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public long CommentKey { get; set; }
        public string ReferenceNumber { get; set; }
        public Nullable<bool> IsAuthorized { get; set; }
        public Nullable<System.DateTime> BusinessDate { get; set; }
        public Nullable<long> ReasonCodeKey { get; set; }
        public Nullable<long> StoreCurrencyKey { get; set; }
        public Nullable<decimal> StoreCurrencyExchangeRate { get; set; }


        public virtual ICollection<PurPurchaseOrderDetail> PurPurchaseOrderDetail { get; set; }

   }

    public class PurPurchaseOrderDetail
    {
        public long PurchaseOrderDetailKey { get; set; }
        public long PurchaseOrderKey { get; set; }
        public int LineNumber { get; set; }
        public long WarehouseKey { get; set; }
        public long ProductKey { get; set; }
        public string Description { get; set; }
        public long TaxKey { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public bool PriceOverriden { get; set; }
        public bool TaxOverridden { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityReceived { get; set; }
        public decimal QuantityOnHold { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalTaxableAmount { get; set; }
        public decimal Tax { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal Total { get; set; }
        public int Status { get; set; }
        public long CommentKey { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public decimal ItemsPerUnit { get; set; }
        public Nullable<long> UOMKey { get; set; }
        public Nullable<decimal> UOMQuantity { get; set; }
        public Nullable<decimal> UOMQuantityReceived { get; set; }
        public Nullable<long> ReasonCodeKey { get; set; }

        public virtual PurPurchaseOrder PurPurchaseOrder { get; set; }



    }
}
