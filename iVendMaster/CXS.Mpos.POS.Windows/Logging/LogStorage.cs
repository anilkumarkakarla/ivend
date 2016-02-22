using System;
using System.IO;
using CXS.Mpos.Core;
using Windows.UI.Xaml;
using Windows.Storage;

namespace CXS.Mpos.POS.Windows
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
			if (Instance == null)
			{
				lock (InstanceLock)
				{
					if (Instance == null)
					{
						Instance = new LogStorage ();
						Instance.LogConfiguration = logConfiguration;
						Instance.InitializeCore ();
					}
				}
			}
		}

		public override void InitializeLogFolder (string logFolderName)
		{

			this.LogDirectoryPath = Path.Combine (ApplicationData.Current.LocalFolder.Path, logFolderName);
			Directory.CreateDirectory (this.LogDirectoryPath);
			this.CurrentLogFilePath = Path.Combine (this.LogDirectoryPath, LogConfiguration.CurrentLogFileName);
		}

		protected void InitializeCore ()
		{
			this.InitializeAbstractLogStorageCore ();
			Application.Current.UnhandledException += this.CaptureUnhandledException;
		}

		protected override void SaveLogTick ()
		{
			LogMessage logMessage = this.LogManager.DequeueLogMessage ();

			if (logMessage != null)
			{
				File.AppendAllText (this.CurrentLogFilePath, logMessage.ToString (this.LogConfiguration.LogMessageFormat));
				if (this.IsLogFileSizeExceeded (LogConfiguration.LogFileSize))
				{
					File.Copy (this.CurrentLogFilePath,
						Path.Combine (this.LogDirectoryPath, DateTime.Now.ToString (LogConfiguration.ArchivedLogFileNameFormat)));
					File.Create (this.CurrentLogFilePath);
				}
			}
		}

		protected override bool IsLogFileSizeExceeded (ulong filesize)
		{
			return ((ulong)new FileInfo (CurrentLogFilePath).Length) > filesize;
		}

		protected override void CaptureUnhandledException (object sender, object args)
		{
			if (args.GetType () == typeof (UnhandledExceptionEventArgs))
			{
				this.LogManager.PrintException (LogStorage.LoggerId, ((UnhandledExceptionEventArgs)args).Exception);
			}
		}

	}
}