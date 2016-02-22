using System.Collections.Generic;
using CXS.Core.Entities;
using Newtonsoft.Json;
using CXS.Core.Framework.Data;
using System;

namespace CXS.PosCommon
{
	public class UserService : Service, IUserRepository
	{
		public UserService(IAppSettings settings)
			: base(settings)
		{

		}
		public long AddUser(UserManagement user)
		{
			throw new NotImplementedException();
		}
	}
}
