using CXS.Core.Common.Logging;
using CXS.Core.Entities;

namespace CXS.Core.Common.Interfaces
{
    public interface IIvendContext
    {
        ILogger Logger { get; }

        User User { get; }
    }
}
