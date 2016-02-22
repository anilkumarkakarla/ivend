using CXS.Core.Framework.Contract.HighLevelHtml;
using CXS.Core.Framework.Domain.Page;

namespace CXS.Core.Framework.Renderer.Orchestrator
{
    public interface IHtmlTranslator
    {
        HighLevelHtml ConstructHighLevelHtml(Page page);
    }
}