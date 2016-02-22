namespace CXS.Core.Common.Logging
{
    public abstract class LogAgentBase : ILogAgent
    {
        public LoggerContext LoggerContext { get; set; }

        protected LogAgentBase()
        { }

        protected LogAgentBase(LoggerContext loggerContext)
        {
            LoggerContext = loggerContext;
        }

        public const string LoggerName = "XiDocs";

        #region abstract members

        public abstract void Flush();

        public abstract void Trace(LogInfo message);

        public abstract void Info(LogInfo message);

        public abstract void Debug(LogInfo message);

        public abstract void Warn(LogInfo message);

        public abstract void Error(LogInfo message);

        public abstract void Fatal(LogInfo message);

        public abstract bool IsDebugEnabled
        { get; }

        public abstract bool IsErrorEnabled
        { get; }

        public abstract bool IsFatalEnabled
        { get; }

        public abstract bool IsInfoEnabled
        { get; }

        public abstract bool IsTraceEnabled
        { get; }

        public abstract bool IsWarnEnabled
        { get; }

        #endregion abstract members
    }
}