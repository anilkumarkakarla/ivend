using CXS.Core.Common;
using CXS.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXS.Tpos.Runtime
{
    static class TposBootstrapper
    {
        public static void Init()
        {
            ServiceContainer.Instance.Register(typeof(MainForm));
            ServiceContainer.Instance.RegisterInstance<IIvendContext>(new TposContext());
        }
    }
}
