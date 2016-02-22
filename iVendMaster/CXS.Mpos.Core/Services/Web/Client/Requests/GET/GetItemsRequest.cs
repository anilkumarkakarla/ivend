using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CXS.Mpos.Core
{
	public class GetItemsRequest : BaseWebRequest
	{
		static private string GET_ITEMS_REQUEST_URL = "items";

		public GetItemsRequest () : base (HttpMethod.Get, GET_ITEMS_REQUEST_URL)
		{
		}
	}
}

