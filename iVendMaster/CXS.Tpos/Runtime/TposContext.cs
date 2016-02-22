using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CXS.Core.Common.Interfaces;
using CXS.Core.Common.Logging;
using CXS.Core.Entities;

namespace CXS.Tpos.Runtime
{
    class TposContext : IIvendContext
    {
        public TposContext()
        {}

        public void ResetLogger(LogActivity activity)
        {
            Logger = Core.Common.Logging.Logger.GetLogger(new LoggerContext {Activity = activity, CurrentUser = User});
        }

        public void SetUser(User user)
        {
            User = user;
        }

        public ILogger Logger { get; private set; }

        public User User { get; private set; }
    }
}
