using System;
using System.Web.Http;
using CXS.Core.Framework.Contract.HighLevelHtml;
using CXS.Core.Framework.Renderer.Orchestrator;

namespace CXS.Core.Framework.RendererApi.Controllers
{
    /// <summary>
    /// Gets Page High Level HTML
    /// </summary>
    public class PageController : ApiController
    {
        private readonly IHtmlTranslator _htmlTranslator;

        public PageController(IHtmlTranslator htmlTranslator)
        {
            _htmlTranslator = htmlTranslator;
        }

        public PageController()
        {
            _htmlTranslator = new HtmlTranslator();
        }

        /// <summary>
        /// Get High Level HTML for the page
        /// </summary>
        /// <param name="pageId">page id</param>
        /// <returns>High Level HTML</returns>
        [Route("api/renderer/{pageId}")]
        public HighLevelHtml GetPage(Guid pageId)
        {
            Orchestrator orch = new Orchestrator(_htmlTranslator);
            var highLevelHtml = orch.GetPage();
            return highLevelHtml;
        }
    }
}
