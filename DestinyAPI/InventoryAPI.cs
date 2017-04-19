using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DestinyAPI
{
    public static class InventoryAPI
    {
        public static async Task<CharacterInventoryData> Get(string MemberId, string CharacterId)
        {
            var data = await BungieAPI.Get("/1/Account/" + MemberId + "/Character/ " + CharacterId + "/Inventory/Summary/ ");
            if(data != null)
            {
                var inventory = data.ToObject<CharacterInventoryData>();
                if (inventory != null)
                {
                    if (inventory.items != null)
                    {
                        foreach (var item in inventory.items)
                        {
                            var inv = await InventoryItemAPI.Get(item.itemHash);
                            item.item = inv;
                        }
                    }
                }
                return inventory;
            }
            return null;
        }
    }
}
