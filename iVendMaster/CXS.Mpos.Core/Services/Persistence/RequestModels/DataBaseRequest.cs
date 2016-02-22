using System;

namespace CXS.Mpos.Core
{
	public class DataBaseRequest
	{
		public string Query { get; set; }

		public DataBaseRequest ()
		{
		}

		public DataBaseRequest (string request)
		{
			this.Query = request;
		}
	}
}

