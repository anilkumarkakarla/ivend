
using System;
using CXS.Core.Common.Logging;
using CXS.Core.Framework.Renderer.Helper;
using CXS.Core.Framework.Contract.HighLevelHtml;

namespace CXS.Core.Framework.Renderer.Orchestrator
{
    /// <summary>
    /// The server side orchestrator, reads the page object from the data store, 
    /// translates to high level HTML and also retrieve the controls package information 
    /// and handover to client side orchestrator.
    /// </summary>
    public class Orchestrator
    {
        private readonly IHtmlTranslator _htmlTranslator;
        private readonly ILogger _logger = Logger.GetLogger(new LoggerContext());
        public Orchestrator(IHtmlTranslator htmlTranslator)
        {
            _htmlTranslator = htmlTranslator;
        }
        /// <summary>
        /// This method gets the page object from datasource
        /// </summary>
        /// <returns>High level html</returns>
        public HighLevelHtml GetPage()
        {
            PageFactory pageFactory = new PageFactory();
            try
            {
                string configValue = Utility.GetConfigurationValue(Constants.PageRepository);
                PageRepositoryValue repositoryValue = (PageRepositoryValue)Enum.Parse(typeof(PageRepositoryValue), configValue);
                IPageRepository repository = pageFactory.GetRepository(repositoryValue);
                var page = repository.GetPage();

                return _htmlTranslator.ConstructHighLevelHtml(page);
            }
            catch (Exception ex)
            {
                _logger.Error("Uncaught exception in GetPage Method execution.", ex);
            }
            return null;

        }
    }
}
