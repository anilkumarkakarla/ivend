using System;
using System.Net.Http;
using System.Collections.Generic;

namespace CXS.Mpos.Core
{
	public class BaseWebRequest : HttpRequestMessage
	{
		public BaseWebRequest () : base ()
		{
		}

		public BaseWebRequest (HttpMethod httpMethod, string requestUri, Dictionary <string, string> parameters = null) : base (httpMethod, RequestURLAsString (requestUri, parameters))
		{
		}

		static protected string RequestURLAsString (string requestUri, Dictionary<string, string> parameters)
		{
			string parametersString = "";
			if (parameters != null) {
				foreach (string key in parameters.Keys) {
					parametersString = parametersString + "&" + key + "=" + parameters [key].ToString ();
				}
				if (parametersString.Length > 0) {
					parametersString = parametersString.Substring (1);
				}
			}
			parametersString = String.Join ("?", new String[]{ requestUri, parametersString });

			return parametersString;
		}
	}
}

