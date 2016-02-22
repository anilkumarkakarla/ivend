using System;
using System.IO;
using CXS.Mpos.Core;
using Android.Runtime;

namespace CXS.Mpos.POS.Android
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

		public override void InitializeLogFolder (string logFolderName)
		{
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			this.LogDirectoryPath = Path.Combine (documents, logFolderName);
			Directory.CreateDirectory (this.LogDirectoryPath);
			this.CurrentLogFilePath = Path.Combine (this.LogDirectoryPath, LogConfiguration.CurrentLogFileName);
		}

		protected void InitializeCore ()
		{
			this.InitializeAbstractLogStorageCore ();
			AppDomain.CurrentDomain.UnhandledException += this.CaptureUnhandledException;
			AndroidEnvironment.UnhandledExceptionRaiser += this.CaptureUnhandledException;
		}

		protected override void SaveLogTick ()
		{
			LogMessage logMessage = this.LogManager.DequeueLogMessage ();

			if (logMessage != null) {
				System.IO.File.AppendAllText (this.CurrentLogFilePath, logMessage.ToString (this.LogConfiguration.LogMessageFormat));
				if (this.IsLogFileSizeExceeded (LogConfiguration.LogFileSize)) {
					System.IO.File.Copy (this.CurrentLogFilePath, 
						Path.Combine (this.LogDirectoryPath, DateTime.Now.ToString (LogConfiguration.ArchivedLogFileNameFormat)));
					System.IO.File.Create (this.CurrentLogFilePath);
				}
			}
		}

		protected override bool IsLogFileSizeExceeded (ulong filesize)
		{
			return (ulong)new Java.IO.File (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments)).Length () > filesize;
		}

		protected override void CaptureUnhandledException (object sender, object args)
		{
			if (args.GetType () == typeof (UnhandledExceptionEventArgs)) {
				this.LogManager.PrintException (LogStorage.LoggerId, (Exception)((UnhandledExceptionEventArgs)args).ExceptionObject);
			} else if (args.GetType () == typeof (RaiseThrowableEventArgs)) {
				this.LogManager.PrintException (LogStorage.LoggerId, ((RaiseThrowableEventArgs)args).Exception);
			}
		}
	}
}