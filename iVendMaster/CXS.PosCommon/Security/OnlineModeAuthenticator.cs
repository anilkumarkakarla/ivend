using CXS.Core.Common;
using CXS.Core.Common.Interfaces;
using CXS.Core.Common.Logging;
using CXS.Core.Entities;

namespace CXS.PosCommon.Security
{
    public class OnlineModeAuthenticator :IServiceAuthenticator
    {
        public bool AuthenticateUser(string username, string password, out User onlineUserDetails)
        {
            bool authenticationStatus = false;
            var ivendContext = ServiceContainer.Instance.GetInstance<IIvendContext>() as IIvendContext;
            var logger = ivendContext.Logger as Logger;

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodStart();
            }
            User user = new User {UserName = username};

            onlineUserDetails = user;
            authenticationStatus = true;
            StoreAndRetrieveUserEncryptedData.SaveUserData(username, password);

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodEnd("Online_AuthenticateUser",
                    new[] { new ParamContainer("Authentication Status", authenticationStatus), new ParamContainer("UserDetails", onlineUserDetails), });
            }
            return authenticationStatus;
        }
    }
}
