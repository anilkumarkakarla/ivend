using System;
using CXS.Core.Common.Logging;
using CXS.Core.Framework.Renderer.Helper;

namespace CXS.Core.Framework.Renderer.Orchestrator
{
    public class PageFactory
    {
        private readonly ILogger _logger = Logger.GetLogger(new LoggerContext());

        /// <summary>
        /// Based on value set in configuration file this method will return the instance 
        /// of page repository
        /// </summary>
        /// <param name="repositoryValue">string value set in config file</param>
        /// <returns>IPageRepository instance</returns>
        public IPageRepository GetRepository(PageRepositoryValue repositoryValue)
        {
            IPageRepository repository = null;
            try
            {
                switch (repositoryValue)
                {
                    case PageRepositoryValue.PageRepository:
                        repository = new PageRepository();
                        break;
                    case PageRepositoryValue.PageMockRepository:
                        repository = new PageMockRepository();
                        break;
                    default:
                        repository = new PageMockRepository();
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Uncaught exception in GetRepository Method.", ex);
            }
            return repository;

        }
    }
}
