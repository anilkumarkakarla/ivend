using System;
using System.Collections.Generic;
using System.Text;

namespace CXS.Mpos.Core
{
	public class DataBaseSelectRequest:DataBaseRequest
	{
		public string TableName { get; set; }

		public string Conditions { get; set; }

		public string ColumnsName { get; set; }

		public string OrderBy { get; set; }

		public DataBaseSelectRequest () : base ()
		{
		}

		public DataBaseSelectRequest (string tableName)
		{
			this.TableName = tableName;
			this.Query = "SELECT * FROM " + TableName;
		}

		public DataBaseSelectRequest (string tableName, string columnsName = null, string whereConditions = null, string orderBy = null)
		{
			this.TableName = tableName;
			this.Conditions = whereConditions;
			this.ColumnsName = columnsName;
			this.OrderBy = orderBy;
			this.Query = SelectRequestBuilder (TableName,ColumnsName ,Conditions, OrderBy);
		}

		protected string SelectRequestBuilder (string tableName, string columnsName = null, string whereConditions = null, string orderBy = null)
		{
			if (tableName == null) {
				ArgumentNullException exception = new ArgumentNullException ("Table name is null");
				Log.PrintException (exception, "DataBaseSelectRequest", 33);
				throw exception;
			}
				
			string request = "";

			if (columnsName != null) {
				request = String.Format ("SELECT {0} FROM {1} ", columnsName, tableName);
			} else {
				request = String.Format("SELECT * FROM {0} ", tableName);
			}
			if (whereConditions != null) {
				request = request + String.Format ("WHERE {0}", whereConditions);
			}
			if (orderBy != null) {
				request = request + String.Format ("ORDER BY {0}", whereConditions);
			}

			return request;
		}
	}
}

