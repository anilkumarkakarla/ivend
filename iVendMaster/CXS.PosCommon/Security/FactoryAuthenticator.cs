using CXS.PosCommon.Security;

namespace CXS.PosCommon
{
    public static class FactoryAuthenticator
    {
        public static IServiceAuthenticator CreateAuthenticator(bool isOnline)
        {
            return isOnline ? new OnlineModeAuthenticator() as IServiceAuthenticator : new OfflineModeAuthenticator();
        }
    }
}
