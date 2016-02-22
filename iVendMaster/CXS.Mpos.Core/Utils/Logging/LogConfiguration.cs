using System;
using System.Linq;
using System.Collections.Generic;

namespace CXS.Mpos.Core
{
	public enum LogLevel
	{
		DEBUG = 0,
		INFO,
		WARN,
		ERROR,
		FATAL
	}

	public class LogConfiguration
	{
		public const string ArchivedLogFileNameFormat = "MM-dd-yy_H.mm.ss.fff";

		public const string CurrentLogFileName = "log";

		public const ulong LogFileSize = 1024 * 1024;

		public string LoggerIdFormat = "{0}:{1}";

		public string LogMessageFormat = "[{0:MM/dd/yy H:mm:ss.fff} | {1} | {2}]: {3}";

		public string HttpRequestFormat = "{0} {1}\n{2}";

		public string HttpResponseFormat = "{0} {1} Status Code: {2}\n{3}";

		public string LogFilePath;

		public List<LogLevel> LogLevel = Enum.GetValues (typeof(LogLevel)).Cast<LogLevel> ().ToList ();

		public LogConfiguration ()
		{
			#if !DEBUG
			this.LogLevel.Remove (CXS.Mpos.Core.LogLevel.DEBUG);
			#endif
		}
	}
}