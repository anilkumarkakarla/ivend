using System;
using System.IO;
using CXS.Core.Common;
using CXS.Core.Common.Interfaces;
using CXS.Core.Common.Logging;
using CXS.Core.Common.Utility;
using CXS.Core.Entities;

namespace CXS.PosCommon.Security
{
    public static class StoreAndRetrieveUserEncryptedData
    {
        public static void SaveUserData(string userName, string passWord)
        {
            var logger = GetLogger();

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodStart();
            }
            OfflineUser userDetails = new OfflineUser();
            userDetails.UserName = userName;
            userDetails.HashedPwd = EncryptDecryptUtility.GenerateSaltedHashPwd(userName, passWord);
            SerializationHelper<OfflineUser> serializationObj = new SerializationHelper<OfflineUser>();
            string fileName = GetFileName();
            serializationObj.Save(userDetails, fileName);

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodEnd("SaveUserData",
                    new[] { new ParamContainer("User Details", userDetails) });
            }
        }

        private static Logger GetLogger()
        {
            var ivendContext = ServiceContainer.Instance.GetInstance<IIvendContext>() as IIvendContext;
            var logger = ivendContext.Logger as Logger;
            return logger;
        }

        public static OfflineUser RetrieveUserDetails()
        {
            var logger = GetLogger();
            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodStart();
            }
            string fileName = GetFileName();
            SerializationHelper<OfflineUser> serializationObj = new SerializationHelper<OfflineUser>();
            OfflineUser userDetails = (OfflineUser)(serializationObj.Load(fileName));
            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodEnd("RetrieveUserDetails",
                    new[] { new ParamContainer("User Details", userDetails) });
            }
            return userDetails;
        }

        //TODO: PCL shouldn't work with filesystem, because there is no common FS interface for different platforms.
        //Need to either create common FS interface and inject platform-specific implementations, or work with FS in platfform-specific projects
        //(TPOS, MPOS.Android, MPOS.iOS, etc).
        private static string GetFileName()
        {
            /*string rootFolderPath = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            string folderPath = Path.Combine(rootFolderPath, "CitiXsysTemp");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileLocation = Path.Combine(folderPath, "UserDetails.xml");
            return fileLocation;*/
            return "";
        }
    }
}
