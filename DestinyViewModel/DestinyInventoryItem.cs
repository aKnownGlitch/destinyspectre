using System;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace DestinyViewModel
{
    public class DestinyInventoryItem : BindableBase<DestinyAPI.InventoryItem>
    {
        public DestinyInventoryItem(DestinyAPI.InventoryItem item) : base(item)
        {
            RaisePropertyChanged("ItemName");
            RaisePropertyChanged("Icon");
        }

        public string ItemName
        {
            get { return This.itemName; }
        }

        public ImageSource Icon
        {
            get
            {
                return new BitmapImage(new Uri("https://bungie.net" + This.icon, UriKind.Absolute));
            }
        }
    }
}
