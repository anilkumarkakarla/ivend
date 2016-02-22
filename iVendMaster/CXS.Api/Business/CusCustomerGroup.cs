using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CXS.Api.Business
{
    public class CusCustomerGroup
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long CustomerGroupKey { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public long SalesTaxCodeKey { get; set; }
        public System.DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDefault { get; set; }

    }
}
