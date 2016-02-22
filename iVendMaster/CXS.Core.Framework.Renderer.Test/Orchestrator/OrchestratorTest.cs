using CXS.Core.Framework.Renderer.Orchestrator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CXS.Core.Framework.Renderer.Test.Orchestrator
{
    [TestClass]
    public class OrchestratorTest
    {

        [TestMethod]
        public void GetPageTest()
        {
            Renderer.Orchestrator.Orchestrator orch = new Renderer.Orchestrator.Orchestrator(new HtmlTranslator());
            var result = orch.GetPage();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.HtmlString);
            Assert.AreNotEqual(result, string.Empty);

        }
    }
}
