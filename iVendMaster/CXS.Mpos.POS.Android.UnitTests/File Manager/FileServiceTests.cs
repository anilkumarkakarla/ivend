using System;
using System.IO;
using Android.OS;
using NUnit.Framework;

namespace CXS.Mpos.POS.Android.UnitTests
{
	[TestFixture]
	public class FileServiceTests
	{
		private FileService FService;
		private string FilePath;

		[SetUp]
		public void BeforeTests ()
		{
			FService = new FileService ();

			FilePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "one.txt");

			StreamWriter streamWriter = new StreamWriter (FilePath);
			streamWriter.WriteLine ("data");

			streamWriter.Close ();
        }

		[Test]
		public void SaveFileTests () 
		{
			FService.SaveFile ("value", "key.txt");
            string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "key.txt");
			string result = File.ReadAllText (filePath);
			Assert.True(result.Equals("value"));
			System.IO.File.Delete (filePath);
        }

		[Test]
		public void SaveFileByPathTests () 
		{
			string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "two.txt");
			FService.SaveFileByPath ("string",filePath);
			string result = File.ReadAllText (filePath);
			Assert.True(result.Equals("string"));
			System.IO.File.Delete (filePath);
		}

		[Test]
		public void GetFileTests () 
		{
			string result = FService.GetFile("one.txt");
			Assert.True(result.Equals("data\n"));
		}

		[Test]
		public void GetFileByPathTests () 
		{
			string result = FService.GetFileByPath (FilePath);
			Assert.True(result.Equals("data\n"));
		}
	}
}

