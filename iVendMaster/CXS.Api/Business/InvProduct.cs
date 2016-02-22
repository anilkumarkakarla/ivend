using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CXS.Api.Business
{
    public class InvProduct
    {

        public InvProduct()
        {
            this.InvInventoryItem = new HashSet<InvInventoryItem>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long ProductKey { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
       
        public long PreferedVendorKey { get; set; }
      
        public long ProductGroupKey { get; set; }
        public long SalesTaxCodeKey { get; set; }
        public long PurchaseTaxCodeKey { get; set; }
        public bool AllowFractionalQuantity { get; set; }
        public bool DiscountsAllowed { get; set; }
        public bool HasUpsells { get; set; }
        public bool HasAlternateProducts { get; set; }
        public bool HasWarrantyAvailable { get; set; }
        public bool IsBatchTracked { get; set; }
        public bool IsExchangable { get; set; }
        public bool IsNonStock { get; set; }
        public bool IsRefundable { get; set; }
        public bool IsRentable { get; set; }
        public bool IsSaleable { get; set; }
        public bool IsSerialTracked { get; set; }
        public bool IsWeighed { get; set; }
        public bool IsKit { get; set; }
        public bool IsAssembly { get; set; }
        public bool CanLayaway { get; set; }
        public bool CanOrder { get; set; }
        public bool IsOnHold { get; set; }
        public bool IsTaxExempt { get; set; }
        public bool IsOpenPrice { get; set; }
        public bool IsOpenDescription { get; set; }
        public bool IsInclusiveTaxed { get; set; }
        public decimal DefaultQuantity { get; set; }
        public decimal BasePrice { get; set; }
        public string UPC { get; set; }
        public bool RequireAgeVerification { get; set; }
        public Nullable<int> MinAge { get; set; }
        public bool HasImage { get; set; }
        public long ManufacturerKey { get; set; }
        public string AccountingID { get; set; }
        public int LeadTime { get; set; }
        public Nullable<bool> IsGiftCertificate { get; set; }
        public bool IsZeroValue { get; set; }
        public bool IsPurchasable { get; set; }
        public System.DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsMatrixItem { get; set; }
        public bool IsMatrixChildItem { get; set; }
        public bool IsTwoDimensionalMatrixItem { get; set; }
        public long ParentMartixProductKey { get; set; }
        public Nullable<int> DefaultExpiryPeriod { get; set; }
        public Nullable<int> GiftCertificateType { get; set; }
        public bool PriceOverrideAllowed { get; set; }
        public bool CanSellExpiredItem { get; set; }
        public int ExpiryMessageDays { get; set; }
        public bool CanRefundExpiredItem { get; set; }
        public bool LoyaltyPointsRedeemable { get; set; }
        public bool IsStoreCredit { get; set; }
        public decimal MaximumOpenPrice { get; set; }
        public bool IgnoreDiscountItemsForSaleDiscount { get; set; }
        public bool SaleDiscountsAllowed { get; set; }
        public Nullable<long> ProductClassKey { get; set; }
        public Nullable<long> PackageGroupKey { get; set; }
        public bool HasPackageGroup { get; set; }
        public string GiftCertificatePassTemplate { get; set; }
        public string GiftCertificateEmailTemplate { get; set; }
        public string PassDescription { get; set; }
        public string PassValue { get; set; }
        public long CommentKey { get; set; }
        public Nullable<int> AutoSelectSerialBatchType { get; set; }
        public bool UsePriceEmbeddedBarcode { get; set; }
        public bool MustSwipeCard { get; set; }
        public Nullable<long> UOMGroupKey { get; set; }
        public bool DiscountsGroupAllowed { get; set; }
        public Nullable<long> PurchaseUOMKey { get; set; }
        public Nullable<long> PurchaseUOMPackageKey { get; set; }
        public Nullable<long> SaleUOMKey { get; set; }
        public Nullable<long> SaleUOMPackageKey { get; set; }
        public Nullable<long> InventoryUOMKey { get; set; }
        public Nullable<long> InventoryCountingUOMKey { get; set; }
        public long BarCodeMaskKey { get; set; }
        public Nullable<bool> IsEBTItem { get; set; }
        public string ExternalLink { get; set; }
        public Nullable<bool> ExpiryDateRequiredForBatch { get; set; }
        public Nullable<bool> ExpiryDateRequiredForSerial { get; set; }
        public Nullable<int> ReturnDays { get; set; }
        public Nullable<int> CostingMethod { get; set; }
        public Nullable<int> CostingSubMethod { get; set; }
        public Nullable<long> PrimaryFilterAttributeKey { get; set; }
        public Nullable<long> TwoDimensionalFilterAttributeKey { get; set; }
        public string U_CXS_COO { get; set; }
        public Nullable<int> GracePeriod { get; set; }
        public string U_Test_Field { get; set; }
        public string U_Test2 { get; set; }

        public virtual ICollection<InvInventoryItem> InvInventoryItem { get; set; }


    }

    public class InvInventoryItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long InventoryItemKey { get; set; }
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long ProductKey { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long WarehouseKey { get; set; }
        public long PurchaseTaxKey { get; set; }
        public long SalesTaxKey { get; set; }
        public decimal InStockQuantity { get; set; }
        public decimal InReturnQuantity { get; set; }
        public decimal OnRentQuantity { get; set; }
        public decimal LostQuantity { get; set; }
        public decimal OnLayawayQuantity { get; set; }
        public decimal OnOrderQuantity { get; set; }
        public decimal OnFulFillmentQuantity { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal KitsAvailableToBuild { get; set; }
        public decimal AssembliesAvailableToBuild { get; set; }
        public decimal Price { get; set; }
        public int LeadTime { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modified { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsLocked { get; set; }
        public decimal CountedQuantity { get; set; }
        public bool WasCounted { get; set; }
        public long InventoryCycleSetupKey { get; set; }
        public Nullable<System.DateTime> NextCountDate { get; set; }
        public Nullable<System.DateTime> NextCountTime { get; set; }
        public decimal InTransitQuantity { get; set; }
        public Nullable<decimal> MinimumStockLevel { get; set; }
        public Nullable<decimal> MaximumStockLevel { get; set; }
        public Nullable<int> ReplenishmentMethod { get; set; }
        public Nullable<bool> ConsiderInMRP { get; set; }
        public Nullable<decimal> MinimumOrderQuantity { get; set; }
        public Nullable<long> FulfillmentWarehouseKey { get; set; }
        public Nullable<int> TransactionType { get; set; }
        public Nullable<decimal> AverageCost { get; set; }
        public Nullable<System.DateTime> LastLabelPrintingDate { get; set; }
        public Nullable<decimal> AllocatedQuantity { get; set; }

        public virtual InvProduct InvProduct { get; set; }


    }
}
