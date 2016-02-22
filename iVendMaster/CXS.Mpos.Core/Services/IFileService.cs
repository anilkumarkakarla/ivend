using System;

namespace CXS.Mpos.Core
{
	public interface IFileService
	{
		void SaveFile (string data, string fileName);

		void SaveFileByPath (string data, string filePath);

		string GetFile (string fileName);

		string GetFileByPath (string filePath);

	}
}

