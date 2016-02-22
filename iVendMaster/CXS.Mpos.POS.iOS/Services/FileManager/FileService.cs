using System;
using CXS.Mpos.Core;
using System.IO;

namespace CXS.Mpos.POS.iOS
{
	public class FileService : IFileService
	{
		public FileService ()
		{
		}

		public void SaveFile (string data, string fileName)
		{
			string filePath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), fileName);
			SaveFileByPath (data, filePath);
		}

		public void SaveFileByPath (string data, string filePath)
		{
			if (File.Exists (filePath)) {
				File.AppendAllText (filePath, data);
			} else {
				File.WriteAllText (filePath, data);
			}
		}

		public string GetFile (string fileName)
		{
			string filePath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), fileName);
			return GetFileByPath (filePath);
		}

		public string GetFileByPath (string filePath)
		{
			string data = null;
			if (File.Exists (filePath)) {
				data = File.ReadAllText (filePath);
			} else {
				FileNotFoundException exception = new FileNotFoundException (filePath);
				Log.PrintException (exception);
				throw exception;
			}
			return data;
		}
	}
}