using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CXS.Mpos.Core
{
	public class DataBaseService: IDataBaseService
	{
		private SQLiteConnection Connection;

		public DataBaseService (string dbPath)
		{	
			this.Connection = new SQLiteConnection (dbPath);
		}

		public List<T> PerformRequest<T> (DataBaseRequest request) where T : new()
		{
			List<T> result = new List<T> ();

			if (request is DataBaseSelectRequest) {
				result = PerformSelect<T> ((DataBaseSelectRequest)request);
			}
			if (request is DataBaseUpdateRequest) {
				result = PerformUpdate<T> ((DataBaseUpdateRequest)request);
			}
			if (request is DataBaseInsertRequest) {
				result = PerformInsert<T> ((DataBaseInsertRequest)request);
			}

			return result;
		}


		public void Initialize (DataBaseRequest request)
		{
			try {
				Connection.Execute (request.Query);
			} catch (SQLiteException exception) {
				string errorMessage = exception.Message;
			}
		}

		public void Initialize (string databaseFileName) 
		{
			Assembly assemble = typeof(DataBaseService).GetTypeInfo().Assembly;
			Stream stream = assemble.GetManifestResourceStream ("CXS.Mpos.Core.Resource." + databaseFileName);
			string line = "";
			StringBuilder dbRequest = new StringBuilder();
			StreamReader fileReader = new StreamReader (stream);
			while((line = fileReader.ReadLine()) != null)
			{
				dbRequest.Append (line);
			}
			string[] split = dbRequest.ToString ().Split (new char[] {';'});
			foreach (string s in split) {
				DataBaseRequest dbInitRequest = new DataBaseRequest (s);
				Initialize (dbInitRequest);
			}
		}

		private List<T> PerformSelect<T> (DataBaseSelectRequest selectRequest) where T : new()
		{
			List<T> result = new List<T> ();
			result = Connection.Query<T> (selectRequest.Query);

			return result;
		}

		private List<T> PerformUpdate<T> (DataBaseUpdateRequest updateRequest) where T : new()
		{
			List<T> result = new List<T> ();
			int updateItemNumber = 0;
			updateItemNumber = Connection.Execute (updateRequest.Query);
			result = Connection.Table<T> ().ToList ();

			return result;
		}

		private List<T> PerformInsert<T> (DataBaseInsertRequest insertRequest) where T : new()
		{
			List<T> result = new List<T> ();
			int updateItemNumber = 0;
			updateItemNumber = Connection.Execute (insertRequest.Query);
			result = Connection.Table<T> ().ToList ();

			return result;
		}
	}
}

