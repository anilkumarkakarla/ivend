using System;
using System.Collections.Generic;
using System.Text;

namespace CXS.Mpos.Core
{
	public class DataBaseUpdateRequest:DataBaseRequest
	{
		public string TableName { get; set; }

		public string Values { get; set; }

		public string WhereConditions { get; set; }

		public DataBaseUpdateRequest () : base ()
		{
		}

		public DataBaseUpdateRequest (string tableName, string values, string whereConditions)
		{
			this.TableName = tableName;
			this.Values = values;
			this.WhereConditions = whereConditions;
			this.Query = UpdateRequestBuilder (TableName, Values, WhereConditions);
		}

		protected string UpdateRequestBuilder (string tableName, string values, string whereConditions)
		{
			if ((tableName == null) && (values == null) && (whereConditions == null)) {
				ArgumentNullException exception = new ArgumentNullException ("Table name or Update values are null");
				Log.PrintException (exception, "DataBaseUpdateRequest", 30);
				throw exception;
			}

			string request = String.Format("UPDATE {0} SET {1} WHERE {2}", tableName, values, whereConditions);

			return request;
		}
	}
}

