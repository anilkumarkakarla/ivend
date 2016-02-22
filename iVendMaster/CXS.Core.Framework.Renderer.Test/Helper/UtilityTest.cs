using System;
using CXS.Core.Framework.Renderer.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CXS.Core.Framework.Renderer.Test.Helper
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void GetConfigurationValueForDataSource()
        {
            string value = Utility.GetConfigurationValue(Constants.PageRepository);
            Assert.IsFalse(String.IsNullOrEmpty(value));
        }
    }
}
