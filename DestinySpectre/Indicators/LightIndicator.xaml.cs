using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DestinySpectre
{
    public sealed partial class LightIndicator : UserControl
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
            DependencyProperty.Register("Level", typeof(string), typeof(LightIndicator), new PropertyMetadata("0"));

        public LightIndicator()
        {
            this.InitializeComponent();
            this.Main.DataContext = this;
        }
    }
}
