using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DestinySpectre
{
    public sealed partial class CharacterBanner : UserControl
    {
        public ImageSource BackgroundImage
        {
            get { return GetValue(BackgroundImageProperty) as ImageSource; }
            set { SetValue(BackgroundImageProperty, value); }
        }
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(ImageSource), typeof(CharacterBanner), new PropertyMetadata(""));

        public ImageSource Emblem
        {
            get { return GetValue(EmblemProperty) as ImageSource; }
            set { SetValue(EmblemProperty, value); }
        }
        public static readonly DependencyProperty EmblemProperty =
            DependencyProperty.Register("Emblem", typeof(ImageSource), typeof(CharacterBanner), new PropertyMetadata(""));

        public string ClassType
        {
            get { return GetValue(ClassTypeProperty) as string; }
            set { SetValue(ClassTypeProperty, value); }
        }
        public static readonly DependencyProperty ClassTypeProperty =
            DependencyProperty.Register("ClassType", typeof(string), typeof(CharacterBanner), new PropertyMetadata(""));

        public string Level
        {
            get { return GetValue(LevelProperty) as string; }
            set { SetValue(LevelProperty, value); }
        }
        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register("Level", typeof(string), typeof(CharacterBanner), new PropertyMetadata(""));
        public CharacterBanner()
        {
            InitializeComponent();
            Main.DataContext = this;
        }
    }
}
