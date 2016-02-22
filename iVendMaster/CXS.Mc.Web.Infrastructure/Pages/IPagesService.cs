using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CXS.Mc.Web.Infrastructure.Pages
{
    public interface IPagesService
    {
        IEnumerable<PageItem> GetPages();
    }
}
