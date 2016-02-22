using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CXS.Api.Business
{
    public class TrxTransaction
    {
        public TrxTransaction()
        {
            this.TrxTransactionSaleItem = new HashSet<TrxTransactionSaleItem>();
        }


        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionKey { get; set; }
        public long StoreKey { get; set; }
        public long POSKey { get; set; }
        public long UserKey { get; set; }
        public System.DateTime ActualDate { get; set; }
        public System.DateTime BusinessDate { get; set; }
        public string TransactionId { get; set; }
        public string CustomerRefNumber { get; set; }
        public long CustomerKey { get; set; }
        public long ContactKey { get; set; }
        public long DepartmentKey { get; set; }
        public bool IsTaxExempt { get; set; }
        public bool HasSignature { get; set; }
        public bool HasTaxCodeOverride { get; set; }
        public long TaxCodeKey { get; set; }
        public decimal SubTotal { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal TaxableDiscountAmount { get; set; }
        public decimal StoreTaxableDiscountAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal PostTaxDiscount { get; set; }
        public decimal PostTaxDiscountLiability { get; set; }
        public decimal PostTaxDiscountStoreLiability { get; set; }
        public decimal Total { get; set; }
        public Nullable<System.DateTime> AgeVerificationDate { get; set; }
        public long EventKey { get; set; }
        public long CommentKey { get; set; }
        public bool IsSuspended { get; set; }
        public bool HasSurcharges { get; set; }
        public decimal SurchargesTotal { get; set; }
        public decimal PayableAmount { get; set; }
        public bool HasManagerOverride { get; set; }
        public long ManagerKey { get; set; }
        public bool HasLayaways { get; set; }
        public bool HasLayawaysCancellations { get; set; }
        public bool HasSales { get; set; }
        public bool HasSaleExchanges { get; set; }
        public bool HasDeliveries { get; set; }
        public bool HasRefunds { get; set; }
        public bool HasOrders { get; set; }
        public bool HasFulFillments { get; set; }
        public bool HasARPayments { get; set; }
        public long TillKey { get; set; }
        public System.DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public long ModifiedBy { get; set; }
        public bool HasQuotations { get; set; }
        public Nullable<System.DateTime> QuotationValidityDate { get; set; }
        public decimal ActualDiscountPercent { get; set; }
        public bool HasGiftCertificates { get; set; }
        public bool HasLostSaleItems { get; set; }
        public decimal TotalTaxableAmount { get; set; }
        public bool SaleDiscountAfterTax { get; set; }
        public bool IgnoreDiscountItemsForSaleDiscount { get; set; }
        public string FiscalDocumentNumber { get; set; }
        public string TransactionCustomerName { get; set; }
        public bool HasCouponIssueItems { get; set; }
        public string TrackingNumber { get; set; }
        public long ShippingTypeKey { get; set; }
        public bool LoyaltyPointsAllocationFailed { get; set; }
        public bool HasCancelledSalesOrder { get; set; }
        public bool HasDiscountOverride { get; set; }
        public string TransactionCustomerEmail { get; set; }
        public string LoyaltyId { get; set; }
        public Nullable<bool> GenerateEInvoice { get; set; }
        public Nullable<bool> EInvoiceGenerated { get; set; }
        public Nullable<bool> IsARBill { get; set; }
        public Nullable<bool> ShowFolioNumber { get; set; }
        public int FiscalTransactionType { get; set; }
        public Nullable<bool> IsVoided { get; set; }
        public Nullable<long> POSDocumentNumberSeriesKey { get; set; }
        public Nullable<long> CurrencyKey { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<bool> PassIssued { get; set; }

        public virtual TrxTransactionPayment TrxTransactionPayment { get; set; }
        public virtual TrxTransactionReceipt TrxTransactionReceipt { get; set; }

     
        public virtual TrxTransactionStatus TrxTransactionStatus { get; set; }

        public virtual ICollection<TrxTransactionSaleItem> TrxTransactionSaleItem { get; set; }


    }

    public  class TrxTransactionPayment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionPaymentKey { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionKey { get; set; }
        public long PaymentTypeKey { get; set; }
        public long TenderType { get; set; }
        public long DetailKey { get; set; }
        public int DetailType { get; set; }
        public decimal Amount { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal CashBackAmount { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public string ZipCode { get; set; }
        public int AccountType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long CurrencyKey { get; set; }
        public long ExchangeRateKey { get; set; }
        public bool IsVoided { get; set; }
        public bool HasAuthorization { get; set; }
        public bool HasCardSwipe { get; set; }
        public string AuthorizationCode { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public decimal RoundingAmount { get; set; }
        public string OriginalReferenceNumber { get; set; }
        public bool Refunded { get; set; }
        public string CardNumber { get; set; }
        public decimal ForeignCurrencyAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public bool HasOfflineAuthorization { get; set; }
        public long UniqueIdentifier { get; set; }
        public string AdditionalInformation { get; set; }
        public Nullable<long> CountryKey { get; set; }
        public Nullable<long> BankKey { get; set; }
        public string ValidationCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SurchargeAmount { get; set; }
        public decimal NetPayableAmount { get; set; }
        public bool HasSurcharge { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<System.DateTime> CheckDueDate { get; set; }
        public virtual TrxTransaction TrxTransaction { get; set; }


    }

    public  class TrxTransactionReceipt
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionReceiptKey { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionKey { get; set; }
        public long SiteId { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }

        public virtual TrxTransaction TrxTransaction { get; set; }

    }

    public  class TrxTransactionSaleItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionItemKey { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionKey { get; set; }
        public int Type { get; set; }
        public long WarehouseKey { get; set; }
        public long ProductKey { get; set; }
        public long InventoryItemKey { get; set; }
        public string Description { get; set; }
        public bool HasSerialNumber { get; set; }
        public bool HasBatchNumber { get; set; }
        public bool HasFulfillment { get; set; }
        public bool HasSurcharges { get; set; }
        public bool HasDiscounts { get; set; }
        public long TaxCodeKey { get; set; }
        public decimal TaxRate { get; set; }
        public bool HasTaxCodeOverride { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public int PriceSource { get; set; }
        public decimal Quantity { get; set; }
        public decimal OpenQuantity { get; set; }
        public decimal FullfilledQuantity { get; set; }
        public decimal RefundedQuantity { get; set; }
        public decimal SubTotal { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal SaleDiscountAmount { get; set; }
        public decimal ExclusiveDiscountPercent { get; set; }
        public decimal TaxableDiscountAmount { get; set; }
        public decimal StoreTaxableDiscountAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal SurchargeTotal { get; set; }
        public decimal PostTaxDiscount { get; set; }
        public decimal PostTaxDiscountLiability { get; set; }
        public decimal PostTaxDiscountStoreLiability { get; set; }
        public decimal Total { get; set; }
        public decimal TotalBeforeSaleDiscount { get; set; }
        public decimal TotalPostSaleDiscount { get; set; }
        public long OriginalDocumentKey { get; set; }
        public long OriginalDetailKey { get; set; }
        public long CommentKey { get; set; }
        public long ProductDetailKey { get; set; }
        public bool IsExchange { get; set; }
        public bool IsPromotionApplied { get; set; }
        public decimal PromotionalQuantity { get; set; }
        public bool HasDiscountOverride { get; set; }
        public long TransactionQuotationKey { get; set; }
        public long DeliveryWarehouseKey { get; set; }
        public long BookingStoreKey { get; set; }
        public long BookingWarehouseKey { get; set; }
        public decimal TotalTaxableAmount { get; set; }
        public long ParentTransactionItemKey { get; set; }
        public bool IsUpsellItem { get; set; }
        public long UpsellProductKey { get; set; }
        public bool IsTaxInclusive { get; set; }
        public bool IgnoreDiscountItemsForSaleDiscount { get; set; }
        public int ManualDiscountType { get; set; }
        public decimal ManualDiscountAmount { get; set; }
        public decimal ManualDiscountPercent { get; set; }
        public decimal CouponDiscountAmount { get; set; }
        public decimal SystemDiscountAmount { get; set; }
        public decimal PromotionalDiscountAmount { get; set; }
        public decimal SystemDiscountPercent { get; set; }
        public decimal SystemDiscountType { get; set; }
        public Nullable<decimal> UOMQuantity { get; set; }
        public Nullable<decimal> UOMBaseQuantity { get; set; }
        public Nullable<long> UOMGroupDetailKey { get; set; }
        public Nullable<decimal> AverageCost { get; set; }
        public string ScannedBarcode { get; set; }
        public Nullable<int> ScannedBarcodeSource { get; set; }
        public Nullable<decimal> PaymentDiscount { get; set; }
        public Nullable<bool> IsDeliveryPackage { get; set; }
        public virtual TrxTransaction TrxTransaction { get; set; }
    }

    public  class TrxTransactionStatus
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionStatusKey { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long TransactionKey { get; set; }
        public decimal SalePayableAmount { get; set; }
        public decimal SaleAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal SpecialOrderAmount { get; set; }
        public decimal SpecialOrderPaidAmount { get; set; }
        public decimal SpecialOrderBalanceAmount { get; set; }
        public System.DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public long ModifiedBy { get; set; }
        public Nullable<decimal> LayawayPayableAmount { get; set; }
        public Nullable<decimal> LayawayPaidAmount { get; set; }
        public Nullable<decimal> LayawayBalanceAmount { get; set; }
        public Nullable<decimal> LayawayDepositAmount { get; set; }
        public virtual TrxTransaction TrxTransaction { get; set; }
    }
}
