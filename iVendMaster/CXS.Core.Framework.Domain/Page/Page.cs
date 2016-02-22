using System;
using System.Collections.Generic;

namespace CXS.Core.Framework.Domain.Page
{
    [Newtonsoft.Json.JsonObject(Title = "Page")]
    public class Page
    {
        public Guid Id { get; set; }

        //Resources like bootstrap, Jquery libraries
        public List<string> Dependencies { get; set; }

        public Form Form { get; set; }

        //All the attributes including methods, events, in-line styles
        //CSS classes etc here in proper format.
        public string DomAttributes { get; set; }
    }
}
