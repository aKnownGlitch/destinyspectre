using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinyAPI
{
    public class Membership
    {
        public string iconPath { get; set; }
        public int membershipType { get; set; }
        public string membershipId { get; set; }
        public string displayName { get; set; }
    }

    public static class MembershipAPI
    {
        public static async Task<Membership> Get(string GamerTag)
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

            var requestUri = new Uri("http://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/1/" + GamerTag + "/");

            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                // var array = Newtonsoft.Json.Linq.JArray.Parse(httpResponseBody);
                var body = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(httpResponseBody);
                var response = body["Response"];
                var data = response.First;
                var member = data.ToObject<Membership>();
                return member;
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return null;
        }
    }
}
