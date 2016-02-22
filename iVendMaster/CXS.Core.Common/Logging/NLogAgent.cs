using NLog;

namespace CXS.Core.Common.Logging
{
    public class NLogAgent : LogAgentBase
    {
        private readonly  NLog.Logger _log;

        public NLogAgent(LoggerContext loggerContext)
            : base(loggerContext)
        {
            _log = LogManager.GetLogger(loggerContext.TenantAlias ?? string.Empty);
        }

        public override void Flush()
        {
            _log.Factory.Flush();
        }

        public override void Trace(LogInfo message)
        {
            _log.Log(LogEventInfo.Create(LogLevel.Trace, LoggerContext.TenantAlias, null, message.Message, new object[] {LoggerContext, message}));
        }

        public override void Info(LogInfo message)
        {
            _log.Log(LogEventInfo.Create(LogLevel.Info, LoggerContext.TenantAlias, null, message.Message, new object[] { LoggerContext, message }));
        }

        public override void Debug(LogInfo message)
        {
            _log.Log(LogEventInfo.Create(LogLevel.Debug, LoggerContext.TenantAlias, null, message.Message, new object[] { LoggerContext, message }));
        }

        public override void Warn(LogInfo message)
        {
            _log.Log(LogEventInfo.Create(LogLevel.Warn, LoggerContext.TenantAlias, null, message.Message, new object[] { LoggerContext, message }));
        }

        public override void Error(LogInfo message)
        {
            _log.Log(LogEventInfo.Create(LogLevel.Error, LoggerContext.TenantAlias, null, message.Message, new object[] { LoggerContext, message }));
        }

        public override void Fatal(LogInfo message)
        {
            _log.Log(LogEventInfo.Create(LogLevel.Fatal, LoggerContext.TenantAlias, null, message.Message, new object[] { LoggerContext, message }));
        }

        public override bool IsDebugEnabled => _log.IsDebugEnabled;

        public override bool IsErrorEnabled => _log.IsErrorEnabled;

        public override bool IsFatalEnabled => _log.IsFatalEnabled;

        public override bool IsInfoEnabled => _log.IsInfoEnabled;

        public override bool IsTraceEnabled => _log.IsTraceEnabled;

        public override bool IsWarnEnabled => _log.IsWarnEnabled;
    }
}