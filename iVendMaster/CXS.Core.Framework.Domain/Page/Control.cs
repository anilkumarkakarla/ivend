using System;
using System.Collections.Generic;

namespace CXS.Core.Framework.Domain.Page
{
    public class Control
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public Position Position { get; set; }
        public string TemplateSrc { get; set; }
        public string Directive { get; set; }
        public IEnumerable<string> AdditionalAttributes { get; set; }
        public List<Control> Controls { get; set; }
        public bool IsContainer { get; set; }
    }
}