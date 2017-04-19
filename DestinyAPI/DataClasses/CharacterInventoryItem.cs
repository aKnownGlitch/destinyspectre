namespace DestinyAPI
{
    public class CharacterInventoryItem
    {
        public long itemHash { get; set; }
        public string itemId { get; set; }
        public int quality { get; set; }
        public int damageType { get; set; }
        public long damageHash { get; set; }
        public bool isGridComplete { get; set; }
        public int transferStatus { get; set; }
        public int state { get; set; }
        public int characterIndex { get; set; }
        public long bucketHash { get; set; }
        public InventoryItem item { get; set; }
    }
}
