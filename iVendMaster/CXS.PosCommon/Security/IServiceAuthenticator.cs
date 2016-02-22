using CXS.Core.Entities;

namespace CXS.PosCommon
{
    public interface IServiceAuthenticator
    {
        bool AuthenticateUser(string username, string password, out User userDetails);
    }
}
