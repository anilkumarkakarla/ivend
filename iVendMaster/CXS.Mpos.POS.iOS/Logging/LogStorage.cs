using System;
using System.IO;
using CXS.Mpos.Core;
using Foundation;

namespace CXS.Mpos.POS.iOS
{
	public class LogStorage : AbstractLogStorage
	{
		private static string LoggerId = "LogStorage";
		private string LogDirectoryPath;
		private string CurrentLogFilePath;
		private static volatile LogStorage Instance;
		private static object InstanceLock = new Object ();

		private LogStorage ()
		{
		}

		public static void Initialize (LogConfiguration logConfiguration)
		{
			if (Instance == null) {
				lock (InstanceLock) {
					if (Instance == null) {
						Instance = new LogStorage ();
						Instance.LogConfiguration = logConfiguration;
						Instance.InitializeCore ();
					}
				}
			}
		}

		private void InitializeCore ()
		{
			this.InitializeAbstractLogStorageCore ();
			AppDomain.CurrentDomain.UnhandledException += this.CaptureUnhandledException;
		}

		public override void InitializeLogFolder (string logFolderName)
		{
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			this.LogDirectoryPath = Path.Combine (documents, logFolderName);
			Directory.CreateDirectory (this.LogDirectoryPath);
			this.CurrentLogFilePath = Path.Combine (this.LogDirectoryPath, LogConfiguration.CurrentLogFileName);
		}

		protected override void SaveLogTick ()
		{
			LogMessage logMessage = this.LogManager.DequeueLogMessage ();

			if (logMessage != null) {
				File.AppendAllText (this.CurrentLogFilePath, logMessage.ToString (this.LogConfiguration.LogMessageFormat));
				if (this.IsLogFileSizeExceeded (LogConfiguration.LogFileSize)) {
					File.Copy (this.CurrentLogFilePath, 
						Path.Combine (this.LogDirectoryPath, DateTime.Now.ToString (LogConfiguration.ArchivedLogFileNameFormat)));
					File.Create (this.CurrentLogFilePath);
				}
			}
		}

		protected override bool IsLogFileSizeExceeded (ulong filesize)
		{
			return NSFileManager.DefaultManager.GetAttributes (this.CurrentLogFilePath).Size > filesize;
		}

		protected override void CaptureUnhandledException (object sender, object args)
		{
			this.LogManager.PrintException (LogStorage.LoggerId, (Exception)((UnhandledExceptionEventArgs)args).ExceptionObject);
		}
	}
}