using CXS.Core.Framework.Domain.Page;
using CXS.Core.Framework.Renderer.Helper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
using CXS.Core.Common.Logging;

namespace CXS.Core.Framework.Renderer.Orchestrator
{
    public class PageMockRepository : IPageRepository
    {
        private readonly ILogger _logger = Logger.GetLogger(new LoggerContext());

        /// <summary>
        /// Reads the page object from a mock repository(file read).
        /// </summary>
        /// <returns>Page object</returns>
        public Page GetPage()
        {
            Page page = null;
            try
            {
                var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.JsonObjectFilePath);
                if (File.Exists(filepath))
                {
                    var settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
                    
                    page = JsonConvert.DeserializeObject<Page>(File.ReadAllText(filepath), settings);
                }
                else
                {
                    _logger.Error("Mock Page file not found. File path - "+filepath);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Uncaught exception in GetPage Method execution.", ex);
            }
            return page;
        }
    }
}
