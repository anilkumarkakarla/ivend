using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CXS.Core.Entities;


namespace CXS.Core.Framework.Data
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
