using System.Threading.Tasks;

namespace DestinyAPI
{
    public static class CharactersAPI
    {
        public static async Task<Characters> Get(string MemberId)
        {
            var data = await BungieAPI.Get("/1/Account/" + MemberId + "/Summary/");
            if (data != null)
            {
                var characters = data.ToObject<Characters>();
                return characters;
            }
            return null;
        }
    }
}
