using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CXS.Mc.Web.Infrastructure.Pages
{
    internal class PagesService : IPagesService
    {
        public PagesService()
        {
        }

        public IEnumerable<PageItem> GetPages()
        {
            return new List<PageItem>();
        }
    }
}
