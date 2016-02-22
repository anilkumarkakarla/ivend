using System;
using System.Threading;
using CXS.Core.Entities;

namespace CXS.Core.Common.Logging
{
    public enum LogAssociation
    {
        None,
        Product,
        Customer,
        Order,
    }

    public enum LogActivity
    {
        Undefined,
        Search,
        Save
    }

    public class LoggerContext
    {
        private readonly ThreadLocal<string> _associatedId = new ThreadLocal<string>();
        private readonly ThreadLocal<LogAssociation> _association = new ThreadLocal<LogAssociation>();

        public LoggerContext()
            : this(Guid.NewGuid())
        {
        }

        public LoggerContext(Guid correlationId)
        {
            CorrelationId = correlationId.Equals(Guid.Empty)
                            ? Guid.NewGuid()
                            : correlationId;
        }

        public Guid CorrelationId { get; set; }

        public LogActivity Activity { get; set; }

        public LogAssociation Association
        {
            get
            {
                return _association.Value;
            }
            set
            {
                _association.Value = value;
            }
        }

        public string AssociatedId
        {
            get
            {
                return _associatedId.Value;
            }
            set
            {
                _associatedId.Value = value;
            }
        }

        public Guid? ParentTaskId { get; set; }

        public User CurrentUser { get; set; }

        public string TenantAlias { get; set; }
    }
}