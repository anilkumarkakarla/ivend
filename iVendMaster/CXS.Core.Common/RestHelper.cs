using CXS.Core.Common.Logging;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace CXS.Core.Common
{
    public static class RestHelper
    {
        public static async Task<string> Get(string uri, ILogger logger)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var httpResponseMessage = await client.GetAsync(uri).ConfigureAwait(false);

                    if (httpResponseMessage.IsSuccessStatusCode)
                        return httpResponseMessage.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                logger.Error($"RestUtil.Get for {uri}; Exception - {e.ToString()}");
            }

            return null;
        }

        public static async Task<string> Post(string uri, string data,ILogger logger)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                        return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                logger.Error($"RestUtil.Post for {uri} & Data - {data}; Exception - {e.ToString()}");
            }

            return null;
        }

        public static async Task<string> Delete(string uri,ILogger logger)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var httpResponseMessage = await client.DeleteAsync(uri).ConfigureAwait(false);

                    if (httpResponseMessage.IsSuccessStatusCode)
                        return httpResponseMessage.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                logger.Error($"RestUtil.Delete for {uri}; Exception - {e.ToString()}");
            }

            return null;
        }
    }
}
