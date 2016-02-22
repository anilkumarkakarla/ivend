using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CXS.Api.Business
{
    public class CfgCountry
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long CountryKey { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string AccountingID { get; set; }
        public System.DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
