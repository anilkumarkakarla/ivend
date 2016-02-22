using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXS.Core.Framework.Data
{
    public interface IContract : IOfflineContract, IOnlineContract
    {
    }
}
