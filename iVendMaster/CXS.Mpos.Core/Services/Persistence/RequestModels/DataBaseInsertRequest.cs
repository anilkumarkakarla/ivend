using System;
using System.Text;

namespace CXS.Mpos.Core
{
	public class DataBaseInsertRequest:DataBaseRequest
	{
		public string TableName { get; set; }

		public string ColumnsName { get; set; }

		public string Values { get; set; }

		public DataBaseInsertRequest () : base ()
		{
		}

		public DataBaseInsertRequest (string tableName, string columnsName, string values)
		{
			this.TableName = tableName;
			this.ColumnsName = columnsName;
			this.Values = values;
			this.Query = InsertRequestBuilder (TableName, ColumnsName, Values);
		}

		protected string InsertRequestBuilder (string tableName, string columnsName, string values)
		{
			if ((tableName == null) && (values == null) && (columnsName == null)) {
				ArgumentNullException exception = new ArgumentNullException ("Some parametes of request are null"); 
				Log.PrintException (exception, "DataBaseInsertRequest", 26);
				throw exception;
			}

			string request = String.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, columnsName, values);

			return request;
		}
	}
}

