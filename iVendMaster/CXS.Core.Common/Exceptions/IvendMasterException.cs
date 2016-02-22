using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CXS.Core.Common.Exceptions
{
    class IvendMasterException : Exception
    {
        public IvendMasterException()
        {
        }

        public IvendMasterException(string message) : base(message)
        {
        }

        public IvendMasterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IvendMasterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
