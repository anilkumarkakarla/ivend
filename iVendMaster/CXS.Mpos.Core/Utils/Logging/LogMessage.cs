using System;

namespace CXS.Mpos.Core
{
	public class LogMessage
	{
		public string LoggerId { get; set; }

		public DateTime Time { get; set; }

		public LogLevel LogLevel { get; set; }

		public string Message { get; set; }

		public string ToString (string format)
		{
			return string.Format (format, Time, LoggerId, LogLevel, Message);
		}
	}
}