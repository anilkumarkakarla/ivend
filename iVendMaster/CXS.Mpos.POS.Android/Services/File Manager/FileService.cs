using System;
using CXS.Mpos.Core;
using Android.OS;
using System.IO;


namespace CXS.Mpos.POS.Android
{
	public class FileService : IFileService
	{

		public FileService ()
		{
		}

		public void SaveFile (string data, string fileName)
		{
            string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), fileName);
            if(Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)))
            {
                File.WriteAllText(filePath, data);
            }
            else
            {
                DirectoryNotFoundException exception = new DirectoryNotFoundException("Directory '" + fileName + "' not found");
                Log.PrintException(exception, "FileService", 16);
                throw exception;
            }
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
			string filePath = Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments), fileName);
			string data = "";
			if (File.Exists (filePath)) {
				data = File.ReadAllText (filePath);
			} else {
				FileNotFoundException exception = new FileNotFoundException ("File '"+fileName+"' not found");
				Log.PrintException (exception, "FileService", 40);
				throw exception;
			}
			return data;
		}

		public string GetFileByPath (string filePath)
		{
			string data = "";
			if (File.Exists (filePath)) {
				data = File.ReadAllText (filePath);
			} else {
				FileNotFoundException exception = new FileNotFoundException ("File '"+filePath+"' not found");
				Log.PrintException (exception, "FileService", 50);
				throw exception;
			}
			return data;
		}
	}
}

