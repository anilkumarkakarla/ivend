using System;
using CXS.Mpos.Core;
using System.IO;
using Windows.Storage;

namespace CXS.Mpos.POS.Windows.Services.File_Manager
{
    public class FileService : IFileService
    {

        public FileService()
        {
        }

        public void SaveFile(string data, string fileName)
        {
            string filePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
            if (File.Exists(filePath))
            {
                File.AppendAllText(filePath, data);
            }
            else {
                File.WriteAllText(filePath, data);
            }
        }

        public void SaveFileByPath(string data, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.AppendAllText(filePath, data);
            }
            else {
                File.WriteAllText(filePath, data);
            }
        }

        public string GetFile(string fileName)
        {
            string filePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
            string data = "";
            if (File.Exists(filePath))
            {
                data = File.ReadAllText(filePath);
            }
            else {
                FileNotFoundException exception = new FileNotFoundException("File '" + fileName + "' not found");
                Log.PrintException(exception, "FileService", 50);
                throw exception;
            }
            return data;
        }

        public string GetFileByPath(string filePath)
        {
            string data = "";
            if (File.Exists(filePath))
            {
                data = File.ReadAllText(filePath);
            }
            else {
                FileNotFoundException exception = new FileNotFoundException("File '" + filePath + "' not found");
                Log.PrintException(exception, "FileService", 50);
                throw exception;
            }
            return data;
        }
    }
}
