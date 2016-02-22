using System;
using System.Net.Http;

namespace CXS.Mpos.Core
{
	public interface IWebClient
	{
		string ExecuteRequest (BaseWebRequest request);
	}
}

