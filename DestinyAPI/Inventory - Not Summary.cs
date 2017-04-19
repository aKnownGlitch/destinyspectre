using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinyAPI
{
    public class Objective
    {

    }
    public class Perk
    {
        public string iconPath { get; set; }
        public long perkHash { get; set; }
        public bool isActive { get; set; }
    }
    public class Node
    {
        public bool isActivated { get; set; }
        public int stepIndex { get; set; }
        public int state { get; set; }
        public bool hidden { get; set; }
        public long nodeHash { get; set; }
    }
    public class Progress
    {
        public long dailyProgress { get; set; }
        public long weeklyProgress { get; set; }
        public long currentProgress { get; set; }
        public int level { get; set; }
        public int step { get; set; }
        public long progressToNextLevel { get; set; }
        public long nextLevelAt { get; set; }
        public long progressHash { get; set; }
    }
    public class Stat
    {
        public long statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class EquippableItem
    {
        public long itemHash { get; set; }
        public int bindStatus { get; set; }
        public bool isEquipped { get; set; }
        public long itemInstanceId { get; set; }
        public int itemLevel { get; set; }
        public int stackSize { get; set; }
        public int qualityLevel { get; set; }
        public List<Stat> stats { get; set; }
        public Stat primaryStat { get; set; }
        public bool canEquip { get; set; }
        public int equipRequiredLevel { get; set; }
        public long unlockFlagHashRequiredToEquip { get; set; }
        public int cannotEquipreason { get; set; }
        public int damageType { get; set; }
        public long damageTypeHash { get; set; }
        public long damageTypeNodeIndex { get; set; }
        public int damageTypeStepIndex { get; set; }
        public Progress progression { get; set; }
        public long talentGridHash { get; set; }
        public List<Node> nodes { get; set; }
        public bool useCustomDyes { get; set; }
        public Dictionary<string, string> artRegions { get; set; }
        public bool isEquipment { get; set; }
        public bool isGridComplete { get; set; }
        public List<Perk> perks { get; set; }
        public int location { get; set; }
        public int transferStatus { get; set; }
        public bool locked { get; set; }
        public bool lockable { get; set; }
        public List<Objective> objectives { get; set; }
        public int state { get; set; }
    }

    public class Equippable
    {
        public List<EquippableItem> items { get; set; }
        public long bucketHash { get; set; }
    }
    public class Item
    {
        public List<Item> items { get; set; }
        public long bucketHash { get; set; }
    }

    public class Invisible
    {
        public List<Item> items { get; set; }
        public long bucketHash { get; set; }
    }

    public class Buckets
    {
        public List<Invisible> Invisible { get; set; }
        public List<Item> Item { get; set; }
        public List<Equippable> Equippable { get; set; }
    }

    public class InventoryData
    {
        public Buckets buckets { get; set; }
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
            // var requestUri = new Uri("http://www.bungie.net/Platform/Destiny/1/Account/" + MemberId + "/Items");
            // var requestUri = new Uri("http://www.bungie.net/Platform/Destiny/1/Account/" + MemberId + "/Character/" + CharacterId + "/Inventory/");

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                // var array = Newtonsoft.Json.Linq.JArray.Parse(httpResponseBody);
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
