using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DestinySpectre
{
    public sealed partial class GrimoireIndicator : UserControl
    {
        public string Level
        {
            get { return (string)GetValue(LevelProperty); }
            set
            {
                SetValue(LevelProperty, value);
            }
        }
        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register("Level", typeof(string), typeof(GrimoireIndicator), new PropertyMetadata("0"));

        public GrimoireIndicator()
        {
            this.InitializeComponent();
            this.Main.DataContext = this;
        }
    }
}
