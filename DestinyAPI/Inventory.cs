using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinyAPI
{
    public class InventoryItem
    {
        public long itemHash { get; set; }
        public string itemId { get; set; }
        public int quality { get; set; }
        public int damageType { get; set; }
        public long damageHash { get; set; }
        public bool isGridComplete { get; set; }
        public int transferStatus { get; set; }
        public int state { get; set; }
        public int characterIndex { get; set; }
        public long bucketHash { get; set; }
    }
    public class InventoryData
    {
        public List<InventoryItem> items { get; set; }
        public List<Currency> currencies { get; set; }
    }

    public static class InventoryAPI
    {
        public static async Task<InventoryData> Get(string MemberId, string CharacterId)
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

            var requestUri = new Uri("http://www.bungie.net/Platform/Destiny/1/Account/" + MemberId + "/Character/" + CharacterId + "/Inventory/Summary/");

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                var body = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(httpResponseBody);
                var response = body["Response"];
                var data = response.First.First;
                var inventory = data.ToObject<InventoryData>();
                return inventory;
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return null;
        }
    }
}
