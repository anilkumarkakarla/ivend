using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CXS.Api.Business
{
    public class CusCustomer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long CustomerKey { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public string Title { get; set; }
        public string NickName { get; set; }
        public string CompanyName { get; set; }
        public long AddressKey { get; set; }
        public long BillingAddressKey { get; set; }
        public long ShippingAddressKey { get; set; }
        public long HomeCurrencyKey { get; set; }
        public string Email { get; set; }
        public string WebPage { get; set; }
        public string LoyalityId { get; set; }
        public string AccountingID { get; set; }
        public bool IsTaxExempt { get; set; }
        public string TaxNumber { get; set; }
        public long CustomerGroupKey { get; set; }
        public long SalesTaxCodeKey { get; set; }
        public long StoreKey { get; set; }
        public bool IsActive { get; set; }
        public bool OnHold { get; set; }
        public bool IsMarketing { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public long ShippingTypeKey { get; set; }
        public long PrimaryContactKey { get; set; }
        public bool IsTemplate { get; set; }
        public bool RequireRenter { get; set; }
        public bool RequireSignature { get; set; }
        public long CreditCardKey { get; set; }
        public long PriceListKey { get; set; }
        public bool MultiCurrency { get; set; }
        public bool HasLoyaltyId { get; set; }
        public decimal CustomerDiscount { get; set; }
        public System.DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public long PaymentTypeKey { get; set; }
        public string ElectronicId { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> AnniversaryDate { get; set; }
        public bool IsLoyaltyMember { get; set; }
        public bool CanOrderItems { get; set; }
        public int TaxCompanyType { get; set; }
        public string U_CXS_TREND { get; set; }

        public virtual ArrAccountsReceivable ArrAccountsReceivable { get; set; }

    }

    public  class ArrAccountsReceivable
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long AccountsReceivableKey { get; set; }
       
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long CustomerKey { get; set; }
        public decimal Balance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CreditWarningLevel { get; set; }
        public string BankCountry { get; set; }
        public string Bank { get; set; }
        public string BankAccount { get; set; }
        public string BankBranch { get; set; }
        public decimal AgingAmount1 { get; set; }
        public decimal AgingAmount2 { get; set; }
        public decimal AgingAmount3 { get; set; }
        public decimal AgingAmount4 { get; set; }
        public decimal LastPaymentAmount { get; set; }
        public Nullable<System.DateTime> LastPaymentDate { get; set; }
        public System.DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<decimal> OrderBalance { get; set; }
        public Nullable<decimal> LayawayBalance { get; set; }
        public virtual CusCustomer CusCustomer { get; set; }

    }
}
