using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace DestinyViewModel
{
    public class DestinyArmorItem : BindableBase<DestinyAPI.DestinyArmor>
    {
        public DestinyArmorItem(DestinyAPI.DestinyArmor item) : base(item)
        {
            RaisePropertyChanged("ItemName");
            RaisePropertyChanged("Icon");
        }

        public string ItemName
        {
            get { return This.ItemName; }
        }

        public ImageSource Icon
        {
            get
            {
                return new BitmapImage(new Uri("https://bungie.net" + This.Icon, UriKind.Absolute));
            }
        }
    }
}
