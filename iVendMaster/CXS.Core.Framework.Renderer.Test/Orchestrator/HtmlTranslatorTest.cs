using System.Linq;
using CXS.Core.Framework.Renderer.Orchestrator;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CXS.Core.Framework.Renderer.Test.Orchestrator
{
   [TestClass]
    public class HtmlTranslatorTest
    {
        [TestMethod]
        public void ConstructHighLevelHtmlTest()
        {
            var page = PageUtility.ConstructPageObject();
            var htmlTranslator = new HtmlTranslator();
            var result = htmlTranslator.ConstructHighLevelHtml(page);
            Assert.IsNotNull(result.HtmlString);
        }

       [TestMethod]
       public void ValidateHtmlString()
       {
            var page = PageUtility.ConstructPageObject();
            var htmlTranslator = new HtmlTranslator();
            var result = htmlTranslator.ConstructHighLevelHtml(page);
            var document = new HtmlDocument {OptionFixNestedTags = true};
            document.LoadHtml(result.HtmlString);
            Assert.IsTrue(document != null);
            Assert.AreEqual(0, document.ParseErrors.Count());
       }

       [TestMethod]
       public void ValidateResponseContainsOuterContainer()
       {
            var page = PageUtility.ConstructPageObject();
            var htmlTranslator = new HtmlTranslator();
            var result = htmlTranslator.ConstructHighLevelHtml(page);
            var document = new HtmlDocument { OptionFixNestedTags = true };
            document.LoadHtml(result.HtmlString);
            Assert.AreEqual(0, document.ParseErrors.Count());
            Assert.AreEqual("page-wrapper", document.DocumentNode.FirstChild.Name);
        }

        [TestMethod]
        public void ValidateResponseContainsComponent()
        {
            var page = PageUtility.ConstructPageObject();
            var htmlTranslator = new HtmlTranslator();
            var result = htmlTranslator.ConstructHighLevelHtml(page);
            var document = new HtmlDocument { OptionFixNestedTags = true };
            document.LoadHtml(result.HtmlString);
            Assert.AreEqual(0, document.ParseErrors.Count());
            Assert.AreEqual(document.GetElementbyId(page.Form.Controls.First().Id.ToString()).Name,
                "i-vend-component");
        }

        [TestMethod]
        public void ValidateComponentAttribsPresence()
        {
            var page = PageUtility.ConstructPageObject();
            var htmlTranslator = new HtmlTranslator();
            var result = htmlTranslator.ConstructHighLevelHtml(page);
            var document = new HtmlDocument { OptionFixNestedTags = true };
            document.LoadHtml(result.HtmlString);
            Assert.AreEqual(0, document.ParseErrors.Count());
            Assert.AreEqual(document.GetElementbyId(page.Form.Controls.First().Id.ToString()).HasAttributes,
               true);
        }

        [TestMethod]
        public void ValidateComponentAttributes()
        {
            var page = PageUtility.ConstructPageObject();
            var htmlTranslator = new HtmlTranslator();
            var result = htmlTranslator.ConstructHighLevelHtml(page);
            var document = new HtmlDocument { OptionFixNestedTags = true };
            document.LoadHtml(result.HtmlString);
            Assert.AreEqual(0, document.ParseErrors.Count());
            Assert.AreNotEqual(document.GetElementbyId(page.Form.Controls.First().Id.ToString())
                .Attributes.Count,0);
        }
    }
}
