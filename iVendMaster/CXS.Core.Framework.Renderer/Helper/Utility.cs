using System.Configuration;

namespace CXS.Core.Framework.Renderer.Helper
{
    public class Utility
    {
        /// <summary>
        /// This method reads the config file for parameter value
        /// </summary>
        /// <param name="key">key to be read</param>
        /// <returns>value for respective key</returns>
        public static string GetConfigurationValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
