using System;
using NUnit.Framework;
using System.IO;

namespace CXS.Mpos.POS.iOS.UnitTests
{
	public class FileServiceTest
	{
		private const string KEY = "key";
		private const string VALUE = "value";
		private const string DATA = "data";
		private const string FILENAME = "key.txt"; 
		private const string FILENAME1 = "one.txt";
		private const string FILENAME2 = "two.txt";

		private FileService Service { get; set; }

		[SetUp]
		public void BeforeTests ()
		{
			Service = new FileService ();
			string filePath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), FILENAME);

			StreamWriter streamWriter = new StreamWriter (filePath);
			streamWriter.WriteLine (DATA);
			streamWriter.Close ();
		}

		[Test]
		public void SaveFileTest () 
		{
			Service.SaveFile (VALUE, FILENAME1);
			string filePath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), FILENAME1);
			string result = File.ReadAllText (filePath);
			Assert.True (result.Contains (VALUE));
			File.Delete (filePath);
		}

		[Test]
		public void SaveFileByPathTest () 
		{
			string filePath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), FILENAME2);
			Service.SaveFileByPath (VALUE, filePath);
			string result = File.ReadAllText (filePath);
			Assert.True (result.Contains (VALUE));
			File.Delete (filePath);
		}

		[Test]
		public void GetFileTest () 
		{
			Assert.True (Service.GetFile (FILENAME).Contains (DATA));
		}

		[Test]
		public void GetFileByPathTest () 
		{
			string filePath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), FILENAME);
			Assert.True (Service.GetFileByPath (filePath).Contains (DATA));
		}
	}
}