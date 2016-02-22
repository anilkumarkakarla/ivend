using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CXS.Api.Business;

namespace CXS.Api.BusinessObjects
{
    public class UserRepository:IUserRepository
    {
        public long AddUser(UserManagement user)
        {
            user.ID = 1;
            var result = user.ID;
            return result;
        }
    }
}
