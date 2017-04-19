using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DestinyAPI
{
    public class Characters
    {
        public string membershipId { get; set; }
        public int membershipType { get; set; }
        public List<Character> characters { get; set; }
        public CharacterInventory inventory { get; set; }
        public long grimoireScore { get; set; }
        public long versions { get; set; }
    }
    public class Character
    {
        public CharacterBase characterBase { get; set; }
        public CharacterLevelProgression levelProgression { get; set; }
        public string emblemPath { get; set; }
        public string backgroundPath { get; set; }
        public long emblemHash { get; set; }
        public long characterLevel { get; set; }
        public long baseCharacterLevel { get; set; }
        public bool isPrestigeLevel { get; set; }
        public string precentToNextLevel { get; set; }
        public InventoryData Inventory { get; set; }
        public async Task GetInventory()
        {
            Inventory = await InventoryAPI.Get(characterBase.membershipId, characterBase.characterId);
        }
    }
    public class CharacterBase
    {
        public string membershipId { get; set; }
        public int membershipType { get; set; }
        public string characterId { get; set; }
        public string dateLastPlayer { get; set; }
        public string minutesPlayedThisSession { get; set; }
        public string minutesPlayerTotal { get; set; }
        public long powerLevel { get; set; }
        public long raceHash { get; set; }
        public long genderHas { get; set; }
        public long classHash { get; set; }
        public long currentActivityHash { get; set; }
        public long lastCompletedStory { get; set; }
        public CharacterStats stats { get; set; }
        public Customization customization { get; set; }
        public long grimoireScore { get; set; }
        public PeerView peerView { get; set; }
        public int enderType { get; set; }
        public int classType { get; set; }
        public long buildStatGroupHash { get; set; }
    }
    public class CharacterStats
    {
        public CharacterStat STAT_DEFENSE { get; set; }
        public CharacterStat STAT_INTELLECT { get; set; }
        public CharacterStat STAT_DISCIPLINE { get; set; }
        public CharacterStat STAT_STRENGTH { get; set; }
        public CharacterStat STAT_LIGHT { get; set; }
        public CharacterStat STAT_ARMOR { get; set; }
        public CharacterStat STAT_AGILITY { get; set; }
        public CharacterStat STAT_RECOVERY { get; set; }
        public CharacterStat STAT_OPTICS { get; set; }
    }
    public class CharacterStat
    {
        public long statHash { get; set; }
        public long value;
        public long maximumValue { get; set; }
    }
    public class Customization
    {
        public long presonality { get; set; }
        public long face { get; set; }
        public long skinColor { get; set; }
        public long lipColor { get; set; }
        public long eyeColor { get; set; }
        public long hairColor { get; set; }
        public long featureColor { get; set; }
        public long decalColor { get; set; }
        public bool wearHelmet { get; set; }
        public int hairIndex { get; set; }
        public int featureIndex { get; set; }
        public int decalIndex { get; set; }
    }
    public class PeerView
    {
        public List<Equipment> equipment { get; set; }
    }
    public class Equipment
    {
        public long itemHash { get; set; }
        public List<Dye> dyes { get; set; }
    }
    public class Dye
    {
        public long channelHash { get; set; }
        public long dyeHash { get; set; }
    }
    public class CharacterLevelProgression
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
    public class CharacterInventory
    {
        public List<CharacterItem> items { get; set; }
        public List<Currency> currencies { get; set; }
    }
    public class CharacterItem
    {

    }

    public static class CharactersAPI
    {
        public static async Task<Characters> Get(string MemberId)
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

            var requestUri = new Uri("http://www.bungie.net/Platform/Destiny/1/Account/" + MemberId + "/Summary");

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
                var characters = data.ToObject<Characters>();
                return characters;
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return null;
        }
    }
}
