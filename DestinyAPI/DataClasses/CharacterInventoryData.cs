using System.Collections.Generic;

namespace DestinyAPI
{
    public class CharacterInventoryData
    {
        public List<CharacterInventoryItem> items { get; set; }
        public List<Currency> currencies { get; set; }
    }

}
