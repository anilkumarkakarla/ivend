using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace CXS.Mpos.Core
{
	public class WebClient : IWebClient
	{
		// TODO: change temporary address
		private const string HTTP_SERVER_BASE_URL = "http://localhost:9000";
		private const string HTTP_MEDIA_TYPE = "application/json";
		private const int HTTP_REQUEST_TIMEOUT = 10;

		private HttpClient Client;

		public WebClient (string baseURL = HTTP_SERVER_BASE_URL)
		{
			Client = new HttpClient ();
			Client.BaseAddress = new Uri (baseURL);
			Client.DefaultRequestHeaders.Accept.Clear ();
			Client.DefaultRequestHeaders.Accept.Add (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue (HTTP_MEDIA_TYPE));
			Client.Timeout = TimeSpan.FromSeconds (HTTP_REQUEST_TIMEOUT);
		}

		public string ExecuteRequest (BaseWebRequest request)
		{
			string response = null;
			HttpResponseMessage responseMessage = null;
			Uri requestUri = new Uri (Client.BaseAddress, request.RequestUri);
			try {
				if (request.Method == HttpMethod.Get) {
					responseMessage = Client.GetAsync (requestUri).Result;
				} else if (request.Method == HttpMethod.Post) {
					responseMessage = Client.PostAsync (requestUri, request.Content).Result;
				}
				responseMessage.EnsureSuccessStatusCode ();
				response = responseMessage.Content.ReadAsStringAsync ().Result;
			} catch (Exception e) {
				Log.PrintException (e);
				throw e;
			} 

			return response;
		}
	}
}

