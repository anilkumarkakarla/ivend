using CXS.Core.Entities;

namespace CXS.Core.Framework.Data
{
	public interface IUserRepository
	{
		long AddUser(UserManagement user);
	}
}
