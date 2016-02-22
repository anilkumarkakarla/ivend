using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CXS.Core.Entities
{
    public class CfgAddress : BaseEntity
    {
        public long AddressKey { get; set; }
        public long ContactKey { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Nullable<long> StateKey { get; set; }
        public Nullable<long> CountryKey { get; set; }
        public string County { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public long SalesTaxCodeKey { get; set; }
        public long PurchaseTaxCodeKey { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public string StreetNo { get; set; }
        public string Building { get; set; }
        public string GlobalLocationNumber { get; set; }
    }
}
