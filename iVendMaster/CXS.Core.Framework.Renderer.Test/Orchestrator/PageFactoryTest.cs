using CXS.Core.Framework.Renderer.Helper;
using CXS.Core.Framework.Renderer.Orchestrator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CXS.Core.Framework.Renderer.Test.Orchestrator
{
    [TestClass]
    public class PageFactoryTest
    {
        [TestMethod]
        public void GetPageRepositoryTest()
        {
            PageFactory pageFactory = new PageFactory();
            IPageRepository pageRepository = pageFactory.GetRepository(PageRepositoryValue.PageRepository);
            Assert.IsInstanceOfType(pageRepository,typeof(PageRepository));
        }

        [TestMethod]
        public void GetPageMockRepositoryTest()
        {
            PageFactory pageFactory = new PageFactory();
            IPageRepository pageMockRepository = pageFactory.GetRepository(PageRepositoryValue.PageMockRepository);
            Assert.IsInstanceOfType(pageMockRepository, typeof(PageMockRepository));
        }
    }
}
