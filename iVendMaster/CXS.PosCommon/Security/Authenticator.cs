using CXS.Core.Common;
using CXS.Core.Common.Interfaces;
using CXS.Core.Common.Logging;
using CXS.Core.Entities;

namespace CXS.PosCommon.Security
{
    public class Authenticator
    {
        bool _isOnline = false;
       
        public bool CheckStateAndGetUserDetails(string userName, string password, out User userdetails)
        {
            bool authenticationStatus = false;
            var ivendContext = ServiceContainer.Instance.GetInstance<IIvendContext>() as IIvendContext;
            var logger = ivendContext.Logger as Logger;

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodStart();
            }

            IServiceAuthenticator authenticator = FactoryAuthenticator.CreateAuthenticator(_isOnline);
            authenticationStatus= authenticator.AuthenticateUser(userName, password, out userdetails);

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodEnd("CheckStateAndGetUserDetails",
                    new[] {new ParamContainer("Authentication Status", authenticationStatus)});
            }

            return authenticationStatus;
        }
    }
}
