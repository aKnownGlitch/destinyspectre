using System.Collections.Generic;

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
}
