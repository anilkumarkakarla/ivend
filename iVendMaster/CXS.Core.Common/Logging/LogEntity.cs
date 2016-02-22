using System;

namespace CXS.Core.Common.Logging
{
    public class LogEntity : TableEntity
    {
        public LogEntity()
        { }

        public LogEntity(string correlationId, string rowKey)
            : base(correlationId, rowKey)
        { }

        public string Level { get; set; }

        public string Message { get; set; }

        public string Activity { get; set; }

        public string Association { get; set; }

        public string AssociationId { get; set; }

        public Guid? ParentId { get; set; }

        public string CallerMemberName { get; set; }

        public string CallerFile { get; set; }

        public int CallerLineNumber { get; set; }

        public int ThreadId { get; set; }

        public string ProcessName { get; set; }

        public int ProcessId { get; set; }

        public string User { get; set; }

        public string RoleInstance { get; set; }

        public Guid? ApplicationId { get; set; }

        public int? ApplicationVersionId { get; set; }

        public Guid? RequestId { get; set; }

        public Guid? QueueId { get; set; }
    }
}