using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CXS.Api.Business;

namespace CXS.Api.BusinessObjects
{
   public interface IUserRepository
    {
        long AddUser(UserManagement user);
       
    }
}
