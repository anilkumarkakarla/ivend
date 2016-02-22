using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace CXS.Mpos.Core.Tests
{
	[TestFixture ()]
	public class WebClientTest
	{

		[Test ()]
		public void ExecuteRequestTest ()
		{
			WebClient webClient = new WebClient ();
			GetItemsRequest request = new GetItemsRequest ();
			string result = webClient.ExecuteRequest (request);
			Assert.True (result.Length > 0);
		}
	}
}

