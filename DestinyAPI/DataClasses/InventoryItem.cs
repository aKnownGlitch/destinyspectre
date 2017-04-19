using System.Collections.Generic;

namespace DestinyAPI
{
    public class InventoryItem
    {
        public long itemHash { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string icon { get; set; }
        public bool hasIcon { get; set; }
        public string secondaryIcon { get; set; }
        public string actonName { get; set; }
        public bool hasAction { get; set; }
        public bool deleteOnAction { get; set; }
        public string tierTypeName { get; set; }
        public long tierType { get; set; }
        public string itemTypeName { get; set; }
        public long bucketTypeHash { get; set; }
        long primaryBaseStatHash { get; set; }
        public Stat stats { get; set; }
        public List<long> perkHashes { get; set; }
        public long specialItemType { get; set; }
        public long talentGridHash { get; set; }
        public ItemEquipment equippingBlock { get; set; }
        public bool hasGeometry { get; set; }
        public long statGroupHash { get; set; }
        public List<long> itemLevels { get; set; }
        public long qualityLevel { get; set; }
        public bool equippable { get; set; }
        public bool instanced { get; set; }
        public long rewardItemHash { get; set; }
        // public string values { get; set; }
        public long itemType { get; set; }
        public long itemSubType { get; set; }
        public long classType { get; set; }
        public List<long> itemCategoryHashes { get; set; }
        public List<long> sourceHashes { get; set; }
        public bool exclusive { get; set; }
        public long maxStackSize { get; set; }
        public long itemIndex { get; set; }
        public List<long> setItemHashes { get; set; }
        public string tooltipStyle { get; set; }
        public long questlineItemHash { get; set; }
        public bool needsFullCompletion { get; set; }
        public List<long> objectiveHashes { get; set; }
        public bool allowActions { get; set; }
        public long questTrackingUnlockValueHash { get; set; }
        public long bountyResetUnlockHash { get; set; }
        public long uniquenessHash { get; set; }
        public bool showActivityNodesInTooltip { get; set; }
        public long hash { get; set; }
        public long index { get; set; }
        public bool redacted { get; set; }
    }
}
