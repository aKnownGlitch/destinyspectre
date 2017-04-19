using System.Threading.Tasks;

namespace DestinyAPI
{
    public static class InventoryItemAPI
    {
        public static async Task<InventoryItem> Get(long ItemHash)
        {
            var data = await BungieAPI.Get("/Manifest/InventoryItem/" + ItemHash.ToString() + "/");
            if (data != null)
            {
                var item = data.ToObject<InventoryData>();
                return item.inventoryItem;
            }
            return null;
        }
    }
}
