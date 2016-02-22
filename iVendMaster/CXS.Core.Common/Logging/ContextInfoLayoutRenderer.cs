using System.Text;
using NLog;
using NLog.LayoutRenderers;

namespace CXS.Core.Common.Logging
{
    [LayoutRenderer("contextInfo")]
    public class ContextInfoLayoutRenderer : LayoutRenderer
    {
        // [COR ID: Correlation Id] [PARENT COR ID: Parent Correlation Id] [ACTIVITY: Activity] [TA: Tenant Id] [APP ID: Application Id]/[REQ ID: Request Id] [QUEUE ID: Queue Id] [METHOD: class name/method name (line number)]
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var logInfo = logEvent.Parameters[1] as LogInfo;            
            var loggerContext = logEvent.Parameters[0] as LoggerContext;

            if (logInfo == null || loggerContext == null) return;            

            builder.AppendFormat("[COR ID: {0}]", loggerContext.CorrelationId);

            if (!string.IsNullOrWhiteSpace(loggerContext.ParentTaskId != null ? loggerContext.ParentTaskId.ToString() : ""))
                builder.AppendFormat(" [PARENT COR ID: {0}]", loggerContext.ParentTaskId);

            builder.AppendFormat(" [ACTIVITY: {0}]", loggerContext.Activity);

            if (!string.IsNullOrWhiteSpace(loggerContext.TenantAlias))
                builder.AppendFormat(" [TA: {0}]", loggerContext.TenantAlias);

            OwnerMessage(builder, loggerContext);



            MethodInfo(builder, logInfo);
        }

        // [METHOD: class name/method name (line number)]
        private void MethodInfo(StringBuilder sb, LogInfo message)
        {
            int startAt = message.CallerFile.LastIndexOf('\\') + 1;
            sb.AppendFormat(" [METHOD: {0}.{1} ({2})]",
                            message.CallerFile.Substring(startAt,
                                                         message.CallerFile.LastIndexOf('.') - startAt),
                            message.CallerMemberName,
                            message.CallerLineNumber);
        }

        private void OwnerMessage(StringBuilder sb, LoggerContext loggerContext)
        {
            if (!string.IsNullOrWhiteSpace(loggerContext.AssociatedId))
                switch (loggerContext.Association)
                {
                    case LogAssociation.None:
                        break;

                    default:
                        sb.AppendFormat(" [{0} ID: {1}]", loggerContext.Association.ToString().Substring(0, 3).ToUpper(),
                                        loggerContext.AssociatedId);
                        break;
                }
        }


    }
}