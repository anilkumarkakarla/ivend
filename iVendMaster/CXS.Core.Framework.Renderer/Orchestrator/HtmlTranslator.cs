using System;
using System.IO;
using System.Web.UI;
using System.Text;
using Newtonsoft.Json;
using CXS.Core.Common.Logging;
using CXS.Core.Framework.Contract.HighLevelHtml;
using Control = CXS.Core.Framework.Domain.Page.Control;

namespace CXS.Core.Framework.Renderer.Orchestrator
{
    /// <summary>
    /// This class convert the page object to a high level html
    /// that will be understandable to the client orchestrator
    /// </summary>
    public class HtmlTranslator : IHtmlTranslator
    {
        private const string dependencyTag = "page-dependency";
        private const string templateSrcAttribute = "templatesrc";
        private const string pageWrapperTag = "page-wrapper";
        private readonly ILogger _logger = Logger.GetLogger(new LoggerContext());

        public HtmlTranslator()
        {
        }

        /// <summary>
        /// Constructs the high level html from Page object
        /// </summary>
        /// <param name="page">Page object</param>
        /// <returns>High Level Html</returns>
        public HighLevelHtml ConstructHighLevelHtml(Domain.Page.Page page)
        {
            
            var highLevelHtml = new HighLevelHtml();

            try
            {
                if (page != null)
                {                    
                    var htmlWriter = new StringWriter();
                    using (HtmlTextWriter writer = new HtmlTextWriter(htmlWriter))
                    {
                        writer.RenderBeginTag(pageWrapperTag);
                        foreach (var dependency in page.Dependencies)
                        {
                            writer.AddAttribute(HtmlTextWriterAttribute.Src, dependency);
                            writer.RenderBeginTag(dependencyTag);
                            writer.RenderEndTag();
                        }
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        foreach (var control in page.Form.Controls)
                        {
                            RenderControl(writer, control);
                        }
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }
                    highLevelHtml.HtmlString = htmlWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Uncaught exception in ConstructHighLevelHtml Method.", ex);
            }
            return highLevelHtml;
        }

        private static void RenderControl(HtmlTextWriter writer, Control control)
        {
            GlueStyleAttributes(writer, control);
            GlueAttributes(writer, control);
            writer.RenderBeginTag(control.Directive);

            //Add the Package source attributes here.
            
            if (control.IsContainer)
            {
                foreach (Control innerControl in control.Controls)
                {
                    RenderControl(writer, innerControl);
                }
            }
            writer.RenderEndTag();
        }
        /// <summary>
        /// Add style attributes to control tags
        /// </summary>
        /// <param name="writer">HTML writer</param>
        /// <param name="control">Control</param>
        private static void GlueStyleAttributes(HtmlTextWriter writer, Control control)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, control.Id.ToString());

            var position = new
            {
                control.Size.Height,
                control.Size.Left,
                control.Size.Top,
                control.Size.Width,
                Position = control.Position.ControlPosition
            };
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
            {
                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(jsonWriter, position);
            }

            writer.AddAttribute("position", sb.ToString().ToLower());
        }

        /// <summary>
        /// Add attributes to control tags
        /// </summary>
        /// <param name="writer">HTML writer</param>
        /// <param name="control">Control</param>
        private static void GlueAttributes(HtmlTextWriter writer, Control control)
        {
            writer.AddAttribute(templateSrcAttribute, control.TemplateSrc);
            if (control.AdditionalAttributes != null)
            {
                foreach (var attribute in control.AdditionalAttributes)
                {
                    writer.AddAttribute(attribute, "");
                }
            }
            writer.AddAttribute("columnspan", control.Size.ColumnSpan);
            writer.AddAttribute("rowspan", control.Size.RowSpan);
            writer.AddAttribute("widgetindex", control.Position.WidgetIndex);
        }
    }
}
