using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;

namespace CXS.Mpos.Core
{
	public sealed class LogManager
	{
		private static volatile LogManager Instance;
		private const string LOG_FOLDER_NAME = "logs";

		private Queue<LogMessage> LogMessageQueue;

		private LogConfiguration LogConfiguration;
		private AbstractLogStorage AbstractLogStorage;

		private LogManager ()
		{
		}

		public static LogManager GetInstance ()
		{
			return Instance;
		}

		public static void Initialize (LogConfiguration logConfiguration, AbstractLogStorage logStorage)
		{
			Instance = new LogManager ();
			Instance.LogConfiguration = logConfiguration;
			Instance.LogMessageQueue = new Queue<LogMessage> ();
			Instance.AbstractLogStorage = logStorage;
			if (!Instance.IsDebugMode ()) {
				Instance.AbstractLogStorage.InitializeLogFolder (LogManager.LOG_FOLDER_NAME);
			}
		}

		public LogMessage DequeueLogMessage ()
		{
			LogMessage logMessage = null;

			if (this.LogMessageQueue.Count > 0) {
				logMessage = this.LogMessageQueue.Dequeue ();
			}

			return logMessage;
		}

		public string GetLoggerId (string className, int line)
		{
			return (new StringBuilder ()).AppendFormat (this.LogConfiguration.LoggerIdFormat, 
				Path.GetFileNameWithoutExtension (className), 
				line.ToString ()).ToString ();
		}

		public void PrintMessage (LogMessage logMessage)
		{
			if (this.IsDebugMode ()) {
				System.Diagnostics.Debug.WriteLine (this.LogConfiguration.LogMessageFormat, 
					logMessage.Time,
					Enum.GetName (typeof(LogLevel), logMessage.LogLevel),
					logMessage.LoggerId,
					logMessage.Message);
			} else {
				this.LogMessageQueue.Enqueue (logMessage);
			}
		}

		public bool IsDebugMode ()
		{
			return this.LogConfiguration.LogLevel.Contains (LogLevel.DEBUG);
		}

		public void PrintException (string loggerId, Exception exception)
		{
			LogMessage message = new LogMessage ();
			message.LoggerId = loggerId;
			message.LogLevel = LogLevel.ERROR;
			message.Message = exception.Message + "\n" + exception.StackTrace + "\n";
			message.Time = DateTime.Now;

			this.PrintMessage (message);
		}

		public void PrintHttpRequest (string loggerId, HttpRequestMessage request)
		{
			StringBuilder requestString = new StringBuilder ();
			requestString.AppendFormat (this.LogConfiguration.HttpRequestFormat, 
				request.Method, 
				request.RequestUri,
				request.Properties.ToString ()
			);

			LogMessage message = new LogMessage ();
			message.LoggerId = loggerId;
			message.LogLevel = LogLevel.INFO;
			message.Message = requestString.ToString () + "\n";
			message.Time = DateTime.Now;

			this.PrintMessage (message);
		}

		public async void PrintHttpResponse (string loggerId, HttpResponseMessage response)
		{
			StringBuilder responseString = new StringBuilder ();
			string responseMessage = await response.Content.ReadAsStringAsync ();

			responseString.AppendFormat (this.LogConfiguration.HttpResponseFormat, 
				response.RequestMessage.Method, 
				response.RequestMessage.RequestUri,
				response.StatusCode,
				responseMessage
			);

			LogMessage message = new LogMessage ();
			message.LoggerId = loggerId;
			message.LogLevel = LogLevel.INFO;
			message.Message = responseString.ToString () + "\n";
			message.Time = DateTime.Now;

			this.PrintMessage (message);
		}
	}
}