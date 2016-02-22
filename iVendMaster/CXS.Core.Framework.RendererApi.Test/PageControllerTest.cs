using System;
using CXS.Core.Framework.RendererApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CXS.Core.Framework.RendererApi.Test
{
    [TestClass]
   public class PageControllerTest
    {
        [TestMethod]
        public void GetPageTest()
        {
            PageController pageController = new PageController();
            var result = pageController.GetPage(new Guid());
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, string.Empty);
            Assert.IsNotNull(result.HtmlString);
            Assert.AreNotEqual(result.HtmlString,string.Empty);
        }
    }
}
