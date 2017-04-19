using System.Threading.Tasks;

namespace DestinyAPI
{
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
        public CharacterInventoryData Inventory { get; set; }
        public async Task GetInventory()
        {
            Inventory = await InventoryAPI.Get(characterBase.membershipId, characterBase.characterId);
        }
    }
}
