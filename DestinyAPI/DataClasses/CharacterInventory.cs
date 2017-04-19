using System.Collections.Generic;

namespace DestinyAPI
{
    public class CharacterInventory
    {
        public List<CharacterItem> items { get; set; }
        public List<Currency> currencies { get; set; }
    }

}
