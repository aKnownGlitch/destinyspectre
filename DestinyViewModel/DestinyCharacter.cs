using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace DestinyViewModel
{
    public class DestinyCharacter : BindableBase<DestinyAPI.Character>
    {
        public DestinyCharacter(DestinyAPI.Character character) : base(character)
        {
            RaisePropertyChanged("BackgroundImage");
            RaisePropertyChanged("Level");
            RaisePropertyChanged("ClassType");
            RaisePropertyChanged("Emblem");
        }

        public ImageSource BackgroundImage
        {
            get { return new BitmapImage(new Uri("https://bungie.net" + This.backgroundPath, UriKind.Absolute)); }
        }

        public string Level
        {
            get
            {
                return This.characterLevel.ToString();
            }
        }

        public string ClassType
        {
            get
            {
                var cls = "Unknown";
                switch (This.characterBase.classType)
                {
                    case 0:
                        cls = "Titan";
                        break;
                    case 1:
                        cls = "Hunter";
                        break;
                    case 2:
                        cls = "Warlock";
                        break;
                    default:
                        break;
                }
                return cls;
            }
        }

        public ImageSource Emblem
        {
            get
            {
                return new BitmapImage(new Uri("https://bungie.net" + This.emblemPath, UriKind.Absolute));
            }
        }

        public delegate void InventoryLoadedEventHandler(object sender, EventArgs e);
        public event InventoryLoadedEventHandler InventoryLoaded;

        public async Task GetInventory()
        {
            await This.GetInventory();
            TransferInventory();
            RaisePropertyChanged("Inventory");
            _gear = new DestinyGear(This);
            RaisePropertyChanged("Gear");
            InventoryLoaded?.Invoke(this, EventArgs.Empty);
        }

        private ObservableCollection<DestinyInventoryItem> _inventory = new ObservableCollection<DestinyInventoryItem>();
        public ObservableCollection<DestinyInventoryItem> Inventory
        {
            get { return _inventory; }
        }
        private void TransferInventory()
        {
            _inventory.Clear();
            foreach (var item in This.Inventory.items)
            {
                if (item.item != null)
                {
                    _inventory.Add(new DestinyInventoryItem(item.item));
                }
            }
        }

        private DestinyGear _gear;
        public DestinyGear Gear
        {
            get { return _gear; }
        }

    }
}
