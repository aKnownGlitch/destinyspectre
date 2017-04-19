using System;
using System.Threading.Tasks;

namespace XboxID
{
    public static class GamerTag
    {
        private static async Task<string> GetFromApi()
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
            headers.Add("X-AUTH", "0c019ef83c96b7a4ebbff29f1816e392aea97eee");

            var requestUri = new Uri("https://xboxapi.com/v2/accountxuid");

            try
            {
                var result = await httpClient.GetAsync(requestUri);
                if (result.IsSuccessStatusCode)
                {
                    var httpResponseBody = await result.Content.ReadAsStringAsync();
                    var data = Newtonsoft.Json.Linq.JObject.Parse(httpResponseBody);
                    var gamerTag = (string)data["gamertag"];
                    return gamerTag;
                }

            }
            catch (Exception ex)
            {
                var x = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return null;
        }
        public static async Task<string> Get()
        {
            var gamertag = await GamerTagLocal.Get();
            if(gamertag == null)
            {
                gamertag = await GetFromApi();
                if(gamertag != null)
                {
                    await GamerTagLocal.Put(gamertag);
                }
            }
            return gamertag;
        }
    }
}
