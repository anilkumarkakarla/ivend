using System;
using System.Text;
using CXS.Core.Common.Interfaces;
using CXS.Core.Common.Logging;
using static System.String;
using PCLCrypto;
using static PCLCrypto.WinRTCrypto;

namespace CXS.Core.Common.Utility
{
    public static class EncryptDecryptUtility
    {
        public static string GenerateSaltedHashPwd(string userName, string passwordString)
        {
            var ivendContext = ServiceContainer.Instance.GetInstance<IIvendContext>() as IIvendContext;
            var logger = ivendContext.Logger as Logger;

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodStart();
            }
            string password = new System.Net.NetworkCredential(Empty, passwordString).Password;
            string saltedHashValue = Sha256Encrypt( userName, password);

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodEnd("GenerateSaltedHashPwd",
                    new[] { new ParamContainer("Salted Hash Password", saltedHashValue) });
            }
            return saltedHashValue;
        }
        //TODO: need to investigate encription capabilities for PCL. I've tried to use PCLCrypto library,
        //but it crashes on Windows 10.
        public static string Sha256Encrypt( string userName,string password)
        {
            /*string salt = CreateSalt(userName);
            string saltAndPwd = Concat(password, salt);
            var algorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
            byte[] hashedDataBytes = algorithm.HashData(Encoding.UTF8.GetBytes(saltAndPwd));
            string hashedPwd = Concat(ByteArrayToString(hashedDataBytes), salt);
            return hashedPwd;*/
            return password;
        }

        public static string ByteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            foreach (var t in inputArray)
            {
                output.Append(t.ToString("X2"));
            }
            return output.ToString();
        }

        private static string CreateSalt(string userName)
        {
            string username = userName;
            byte[] userBytes;
            string salt;
            userBytes = Encoding.UTF8.GetBytes(username);
            long XORED = 0x00;

            foreach (int x in userBytes)
                XORED = XORED ^ x;

            Random rand = new Random(Convert.ToInt32(XORED));
            salt = rand.Next().ToString();
            salt += rand.Next().ToString();
            salt += rand.Next().ToString();
            salt += rand.Next().ToString();
            return salt;
        }
    }
}

