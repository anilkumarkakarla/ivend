using System;
using System.Runtime.CompilerServices;

namespace CXS.Core.Common.Logging
{
    public class LogInfo
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                DateTime = DateTime.Now;
                ThreadId = Environment.CurrentManagedThreadId;
            }
        }

        public string Tenant { get; set; }

        public string CallerMemberName { get; set; }

        public string CallerFile { get; set; }

        public int CallerLineNumber { get; set; }

        public DateTime DateTime { get; set; }

        public int ThreadId { get; set; }

        public LogAssociation Association
        { get; set; }

        public string AssociatedId
        { get; set; }
    }

    public class Logger : ILogger
    {
        public static ILogger GetLogger(LoggerContext loggerContext)
        {
            return new Logger(loggerContext);
        }

        public static ILogger GetCentralLogger(LogActivity logActivity)
        {
            return new Logger(new LoggerContext
            {
                Activity = logActivity,
                TenantAlias = ""
            });
        }

        private Logger(LoggerContext loggerContext)
        {
            LoggerContext = loggerContext;

            ParentId = loggerContext.ParentTaskId;

            _log = LoggerFactory.LoggerInstance(loggerContext);
        }

        public Guid? ParentId { get; private set; }

        public Guid CorrelationId { get; private set; }

        public LoggerContext LoggerContext { get; }

        public void UpdateAssociation(LogAssociation association, string associatedId)
        {
            LoggerContext.Association = association;
            LoggerContext.AssociatedId = associatedId;
        }

        public LogActivity Activity { get; set; }

        private readonly ILogAgent _log;

        #region Trace
        public bool IsTraceEnabled => _log.IsTraceEnabled;

        public void Flush()
        {
            _log.Flush();
        }

        public void Trace(string message, [CallerMemberName] string memberName = "",
                          [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Trace(new LogInfo
                {
                    Message = message,
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }

        public bool IsMethodLogEnabled => IsTraceEnabled;

        public void MethodStart(string message = "", ParamContainer[] inParas = null,
                                [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "",
                                [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Trace(new LogInfo
                {
                    Message = $"START: {message} {inParas?.ToInputMessage()}",
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association= LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }

        public void MethodEnd(string message = "", ParamContainer[] outParas = null,
                              [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "",
                              [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Trace(new LogInfo
                {
                    Message = $"END: {message} {outParas?.ToOutputMessage()}",
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }
        #endregion Trace

        #region Debug
        public bool IsDebugEnabled => _log.IsDebugEnabled;

        public void Debug(string message, [CallerMemberName] string memberName = "",
                          [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Debug(new LogInfo
                {
                    Message = message,
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }
        #endregion Debug

        #region Info
        public bool IsInfoEnabled => _log.IsInfoEnabled;

        public void Info(string message, [CallerMemberName] string memberName = "",
                         [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Info(new LogInfo
                {
                    Message = message,
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }
        #endregion Info

        #region Warn
        public bool IsWarnEnabled => _log.IsWarnEnabled;

        public void Warn(string message, [CallerMemberName] string memberName = "",
                         [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Warn(new LogInfo
                {
                    Message = message,
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }

        public void Warn(string message, Exception exception, [CallerMemberName] string memberName = "",
                         [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Warn(new LogInfo
                {
                    Message = $"{message}, Exception: {exception}",
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }
        #endregion Warn

        #region Error
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        public void Error(string message, [CallerMemberName] string memberName = "",
                          [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Error(new LogInfo
                {
                    Message = message,
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }

        //public void Error(string code, string doingWhat, Exception exception)
        //{
        //    _log.ErrorFormat("Err:{0}, while:{1}, exception:{2}", code, doingWhat, exception);
        //}

        public void Error(string message, Exception exception, [CallerMemberName] string memberName = "",
                          [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Error(new LogInfo
                {
                    Message = $"{message}, Exception: {exception}",
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }

        #endregion Error

        #region Fatal
        public bool IsFatalEnabled => _log.IsFatalEnabled;

        public void Fatal(string message, [CallerMemberName] string memberName = "",
                          [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Fatal(new LogInfo
                {
                    Message = message,
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }

        public void Fatal(string message, Exception exception, [CallerMemberName] string memberName = "",
                          [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            _log.Fatal(new LogInfo
                {
                    Message = string.Format("{0}, Exception: {1}", message, exception),
                    CallerMemberName = memberName,
                    CallerFile = sourceFilePath,
                    CallerLineNumber = sourceLineNumber,
                    Association = LoggerContext.Association,
                    AssociatedId = LoggerContext.AssociatedId
                });
        }

        #endregion Fatal

        public void Dispose()
        { }
    }
}