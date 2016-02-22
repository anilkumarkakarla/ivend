using System;
using System.Runtime.CompilerServices;

namespace CXS.Core.Common.Logging
{
    public interface ILogger : IDisposable
    {
        // Properties
        bool IsTraceEnabled { get; }

        bool IsDebugEnabled { get; }

        bool IsInfoEnabled { get; }

        bool IsWarnEnabled { get; }

        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }

        // Methods

        void Flush();

        void Trace(string message, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        void Debug(string message, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        void Warn(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        void Warn(string message, Exception exception, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        void Error(string message, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        void Error(string message, Exception exception, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        void Fatal(string message, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        void Fatal(string message, Exception exception, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        LoggerContext LoggerContext { get; }

        void UpdateAssociation(LogAssociation association, string associatedId);

        /// <summary>
        /// It indicates that method start/end logging is enabled 
        /// </summary>
        bool IsMethodLogEnabled { get; }

        /// <summary>
        /// To trace start of method with input parameters 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inParas"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        void MethodStart(string message = "", ParamContainer[] inParas = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// To trace end of method with output parameters that includes return values and out/ref parameters
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outParas"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        void MethodEnd(string message = "", ParamContainer[] outParas = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
    }
}