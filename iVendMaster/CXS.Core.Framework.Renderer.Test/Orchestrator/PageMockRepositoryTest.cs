using CXS.Core.Framework.Renderer.Orchestrator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CXS.Core.Framework.Renderer.Test.Orchestrator
{
    [TestClass]
   public class PageMockRepositoryTest
    {
        [TestMethod]
        public void GetPageTest()
        {
            PageMockRepository pageMockRepository = new PageMockRepository();
            var result = pageMockRepository.GetPage();
            Assert.AreNotEqual(result, null);
            Assert.AreNotEqual(result, string.Empty);
        }
    }
}
