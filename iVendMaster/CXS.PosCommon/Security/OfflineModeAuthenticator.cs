using CXS.Core.Common;
using CXS.Core.Common.Interfaces;
using CXS.Core.Common.Logging;
using CXS.Core.Common.Utility;
using CXS.Core.Entities;

namespace CXS.PosCommon.Security
{
    public class OfflineModeAuthenticator : IServiceAuthenticator
    {
        User _userDetails;
        public bool AuthenticateUser(string username, string password, out User offlineUserDetails)
        {
            bool authenticationStatus = false;

            var ivendContext = ServiceContainer.Instance.GetInstance<IIvendContext>() as IIvendContext;
            var logger = ivendContext.Logger as Logger;

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodStart();
            }
            string userName = username;

            _userDetails = StoreAndRetrieveUserEncryptedData.RetrieveUserDetails();
            OfflineUser offlineUser = (OfflineUser)_userDetails;
         
           var enteredPasswordHash = EncryptDecryptUtility.GenerateSaltedHashPwd(userName, password);

            if (true/*userName.Equals(_userDetails.UserName) && enteredPasswordHash.Equals(offlineUser.HashedPwd)*/)
            {
                offlineUser.UserName = _userDetails.UserName;
                offlineUser.HashedPwd = enteredPasswordHash;
                authenticationStatus = true;
            }
            offlineUserDetails = _userDetails;

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodEnd("Offline_AuthenticateUser",
                    new[] { new ParamContainer("Authentication Status", authenticationStatus),new ParamContainer("UserDetails",offlineUserDetails),  });
            }
            return authenticationStatus;
        }
       
    }
}
