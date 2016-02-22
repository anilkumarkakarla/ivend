using System.Text;
using System.Threading.Tasks;
using System.IO;
using CXS.Mpos.Core;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage;

namespace CXS.Mpos.POS.Windows.UnitTests
{
	[TestClass]
	public class WindowsLoggingTests
	{
		private string LogDirectoryPath;
		private string CurrentLogFilePath;

		[TestInitialize]
		public void BeforeEachTests ()
		{
			LogStorage.Initialize (new LogConfiguration ());
			LogDirectoryPath = Path.Combine (ApplicationData.Current.LocalFolder.Path, "logs");
			Directory.CreateDirectory (LogDirectoryPath);
		}

		

		[TestMethod]
		public void LogFolderIsCreated ()
		{
			Assert.IsTrue (Directory.Exists (this.LogDirectoryPath));
		}

		[TestMethod]
		public void DebugMessageDoesNotExistInLogFileInReleaseMode ()
		{
			string message = "Debug message";
			Log.Debug (message);
			this.CurrentLogFilePath = Path.Combine (this.LogDirectoryPath, LogConfiguration.CurrentLogFileName);

			Task.Factory.StartNew (async () =>
			{
				await Task.Delay (1000);
				Assert.IsTrue (File.Exists (this.LogDirectoryPath));
				byte[] byteArray = Encoding.UTF8.GetBytes (LogDirectoryPath);
				MemoryStream stream = new MemoryStream (byteArray);
				StreamReader logFileReader = new StreamReader (stream);
				Assert.IsFalse (logFileReader.ReadLine ().Contains (message));
			}, TaskCreationOptions.None);
		}

		[TestMethod]
		public void LogMessageExistsInLogFile ()
		{
			string message = "Info-citixsys-message";
			Log.Info (message);
			this.CurrentLogFilePath = Path.Combine (this.LogDirectoryPath, LogConfiguration.CurrentLogFileName);

			Task.Factory.StartNew (async () =>
			{
				await Task.Delay (1000);
				Assert.IsTrue (File.Exists (this.CurrentLogFilePath));
				byte[] byteArray = Encoding.UTF8.GetBytes (CurrentLogFilePath);
				MemoryStream stream = new MemoryStream (byteArray);
				StreamReader logFileReader = new StreamReader (stream);
				Assert.IsTrue (logFileReader.ReadLine ().Contains (message));
			}, TaskCreationOptions.None);
		}
	}
}