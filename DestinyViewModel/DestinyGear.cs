using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace DestinyViewModel
{
    public class DestinyGear : BindableBase<DestinyAPI.Character>
    {
        public DestinyGear(DestinyAPI.Character character) : base(character)
        {
            LightLevel = This.characterBase.powerLevel.ToString();
            IntellectLevel = This.characterBase.stats.STAT_INTELLECT.value.ToString();
            DisciplineLevel = This.characterBase.stats.STAT_DISCIPLINE.value.ToString();
            StrengthLevel = This.characterBase.stats.STAT_STRENGTH.value.ToString();

            foreach(var i in This.Inventory.items)
            {
                switch (i.item.itemTypeName)
                {
                    case "Warlock Subclass":
                    case "Hunter Subclass":
                    case "Titan Subclass":
                        Subclass = new DestinyInventoryItem(i.item);
                        RaisePropertyChanged("Subclass");
                        SubclassIcon = Subclass.Icon;
                        RaisePropertyChanged("SubclassIcon");
                        break;
                    case "Hand Cannon":
                    case "Fusion Rifle":
                    case "Auto Rifle":
                    case "Scout Rifle":
                        Primary = new DestinyInventoryItem(i.item);
                        break;
                    case "Shotgun":
                    case "Sniper Rifle":
                        Secondary = new DestinyInventoryItem(i.item);
                        break;
                    case "Rocket Launcher":
                    case "Machine Gun":
                        Heavy = new DestinyInventoryItem(i.item);
                        break;
                    case "Ghost Shell":
                        Ghost = new DestinyInventoryItem(i.item);
                        break;
                    case "Helmet":
                        Helmet = new DestinyInventoryItem(i.item);
                        break;
                    case "Chest Armor":
                        ChestArmor = new DestinyInventoryItem(i.item);
                        break;
                    case "Gauntlets":
                        Gauntlets = new DestinyInventoryItem(i.item);
                        break;
                    case "Leg Armor":
                        Boots = new DestinyInventoryItem(i.item);
                        break;
                    case "Warlock Bond":
                    case "Hunter Cloak":
                    case "Titan Mark":
                        ClassItem = new DestinyInventoryItem(i.item);
                        break;
                    case "Warlock Artifact":
                    case "Hunter Artifact":
                    case "Titan Artifact":
                        Artifact = new DestinyInventoryItem(i.item);
                        break;
                    default:
                        Console.WriteLine("Found Item Type = " + i.item.itemTypeName + " Item: " + i.item.itemName);
                        break;
                }
            }
        }

        public string LightLevel { get; set; }
        public string IntellectLevel { get; set; }
        public string DisciplineLevel { get; set; }
        public string StrengthLevel { get; set; }
        public ImageSource SubclassIcon { get; set; }
        public DestinyInventoryItem Subclass { get; set; }
        public DestinyInventoryItem Primary { get; set; }
        public DestinyInventoryItem Secondary { get; set; }
        public DestinyInventoryItem Heavy { get; set; }
        public DestinyInventoryItem Ghost { get; set; }
        public DestinyInventoryItem Helmet { get; set; }
        public DestinyInventoryItem Gauntlets { get; set; }
        public DestinyInventoryItem ChestArmor { get; set; }
        public DestinyInventoryItem Boots { get; set; }
        public DestinyInventoryItem ClassItem { get; set; }
        public DestinyInventoryItem Artifact { get; set; }
    }
}
