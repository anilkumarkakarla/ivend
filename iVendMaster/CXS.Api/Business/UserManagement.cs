using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CXS.Api.Business
{
    public class UserManagement
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailID { get; set; }
    }
}
