using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace CXS.Mpos.Core
{
	public class Log
	{
		private static LogManager LogManager = LogManager.GetInstance ();

		private static void PrintMessage (string loggerId, LogLevel type, string msg)
		{
			LogMessage message = new LogMessage ();
			message.LoggerId = loggerId;
			message.LogLevel = type;
			message.Message = msg + "\n";
			message.Time = DateTime.Now;

			LogManager.PrintMessage (message);
		}

		[Conditional("DEBUG")]
		public static void Debug (string msg, [CallerFilePath] string className = "", [CallerLineNumber] int line = 0)
		{
			PrintMessage (LogManager.GetLoggerId (className, line), LogLevel.DEBUG, msg);
		}

		public static void Info (string msg, [CallerFilePath] string className = "", [CallerLineNumber] int line = 0)
		{
			PrintMessage (LogManager.GetLoggerId (className, line), LogLevel.INFO, msg);
		}

		public static void Warn (string msg, [CallerFilePath] string className = "", [CallerLineNumber] int line = 0)
		{
			PrintMessage (LogManager.GetLoggerId (className, line), LogLevel.WARN, msg);
		}

		public static void Error (string msg, [CallerFilePath] string className = "", [CallerLineNumber] int line = 0)
		{
			PrintMessage (LogManager.GetLoggerId (className, line), LogLevel.ERROR, msg);
		}

		public static void Fatal (string msg, [CallerFilePath] string className = "", [CallerLineNumber] int line = 0)
		{
			PrintMessage (LogManager.GetLoggerId (className, line), LogLevel.FATAL, msg);
		}

		public static void PrintException (Exception exception, [CallerFilePath] string className = "", [CallerLineNumber] int line = 0)
		{
			LogManager.PrintException (LogManager.GetLoggerId (className, line), exception);
		}

		public static void PrintHttpRequest (HttpRequestMessage request, [CallerFilePath] string className = "", [CallerLineNumber] int line = 0)
		{
			LogManager.PrintHttpRequest (LogManager.GetLoggerId (className, line), request);
		}

		public static void PrintHttpResponse (HttpResponseMessage response, [CallerFilePath] string className = "", [CallerLineNumber] int line = 0)
		{
			LogManager.PrintHttpResponse (LogManager.GetLoggerId (className, line), response);
		}
	}
}