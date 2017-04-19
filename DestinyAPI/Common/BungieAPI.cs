using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace DestinyAPI
{
    public static class BungieAPI
    {
        public static async Task<JToken> Get(string APIRequest)
        {
            var httpClient = new Windows.Web.Http.HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            var header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                return null;
            }
            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                return null;
            }
            headers.Add("X-API-KEY", "3ed5169d5cb743eea1d72b9c6b101c3a");

            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";

            var requestUri = new Uri("http://www.bungie.net/Platform/Destiny" + APIRequest);

            try
            {
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                var body = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(httpResponseBody);
                var response = body["Response"];
                return response.First.First;
            }
            catch
            {
                return null;
            }
        }
    }
}
