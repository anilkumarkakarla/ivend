using System;
using System.Collections.Generic;
using CXS.Core.Framework.Domain.Page;

namespace CXS.Core.Framework.Renderer.Test.Orchestrator
{
    public class PageUtility
    {
        public static Page ConstructPageObject()
        {
            var page = new Page
            {
                Id = new Guid("213dd653-978d-4a7a-8415-bd4050854c32"),
                Dependencies =
                    new List<string>(new[] { "http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" }),
                Form = new Form
                {
                    Controls = new List<Control>
                    { new Control
                                {
                                    Id = new Guid("c8013876-3fcb-49fe-9b0a-90801dbb9452"),
                                    Position = new Position {ControlPosition = "relative"},
                                    Size = new Size
                                    {
                                        Height = "64px",
                                        Left = "-200px",
                                        Top = "100px",
                                        Width = "578px"
                                    },
                                    Module = "ngNextGenWidgetV1",
                                    Interface = "widgetFactoryV1",
                                    ModuleSrc = "http://localhost/feed/package/NextGenWidgetV1.js",
                                    TemplateSrc = "http://localhost/feed/package/NextGenWidgetV1.html"
                                }
                    }
                },
                DomAttributes = "drag='4' drag-channel='A' drop-channel='A' ui-on-drop='onDropOfComponentV1(4, $data)' style='border: dotted; position: relative; ' align='center' class='ui - draggable ui - draggable - handle ui - resizable'"

            };
            return page;
        }
    }
}
