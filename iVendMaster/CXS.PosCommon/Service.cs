using CXS.Core.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CXS.PosCommon
{
	public class Service
	{
		private string _baseUri;

		public string BaseUri
		{
			get
			{
				if (string.IsNullOrEmpty(_baseUri))
				{
					_baseUri = "http://localhost:58158/iVendAPI/V1.0/";
				}

				return _baseUri;
			}
		}

		public Service(IAppSettings settings)
		{
			this._baseUri = settings.WebApiUrl;
		}

		public HttpClient GetHttpClient()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_baseUri + "/iVendAPI/V1.0/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return client;
		}

		public HttpContent GetAsJson(BaseEntity obj)
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			return content;
		}

		public string UpdateItem(BaseEntity entity, string url)
		{
			using (var client = GetHttpClient())
			{
				var content = GetAsJson(entity);
				var response = client.PostAsync(url, content).Result;
				return response.StatusCode.ToString();
			}
		}
	}
}