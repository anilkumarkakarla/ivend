using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using CXS.Mpos.Core;
using CXS.Mpos.POS.Android;

namespace CXS.Mpos.POS.Android.UnitTests
{
	[TestFixture]
	public class LoggingTests
	{
		private string LogDirectoryPath;
		private string CurrentLogFilePath;

		[SetUp]
		public void BeforeEachTests ()
		{
			LogStorage.Initialize (new LogConfiguration ());
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			this.LogDirectoryPath = Path.Combine (documents, "logs");
		}

		[Test]
		public void LogFolderIsCreated ()
		{
			#if DEBUG
			Assert.False (Directory.Exists (this.LogDirectoryPath));
			#else
			Assert.True (Directory.Exists (this.LogDirectoryPath));
			#endif
		}

		[Test]
		public void DebugMessageDoesNotExistInLogFileInReleaseMode ()
		{
			string message = "Debug message";
			Log.Debug (message);
			this.CurrentLogFilePath = Path.Combine (this.LogDirectoryPath, LogConfiguration.CurrentLogFileName);
			#if DEBUG
			Assert.False (File.Exists (this.CurrentLogFilePath));
			#else
			Task.Factory.StartNew (() => {
				Thread.Sleep (1000);
				Assert.True (File.Exists (this.CurrentLogFilePath));
				StreamReader logFileReader = new StreamReader (this.CurrentLogFilePath);
				Assert.False (logFileReader.ReadLine ().Contains (message));
			}, TaskCreationOptions.None);
			#endif
		}

		[Test]
		public void LogMessageExistsInLogFile ()
		{
			string message = "Info message";
			Log.Info (message);
			this.CurrentLogFilePath = Path.Combine (this.LogDirectoryPath, LogConfiguration.CurrentLogFileName);
			#if DEBUG
			Assert.False (File.Exists (this.CurrentLogFilePath));
			#else
			Task.Factory.StartNew (() => {
				Thread.Sleep (1000);
				Assert.True (File.Exists (this.CurrentLogFilePath));
				StreamReader logFileReader = new StreamReader (this.CurrentLogFilePath);
				Assert.True (logFileReader.ReadLine ().Contains (message));
			}, TaskCreationOptions.None);
			#endif
		}
	}
}

