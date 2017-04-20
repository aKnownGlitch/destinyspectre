using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DestinySpectre
{
    public sealed partial class SpectreWait : UserControl
    {
        private Storyboard storyboard;
        public SpectreWait()
        {
            this.InitializeComponent();
            storyboard = Resources["SpectreWaitSB"] as Storyboard;
            storyboard.Begin();
        }
    }
}
