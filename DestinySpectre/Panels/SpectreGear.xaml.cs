using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DestinySpectre
{
    public sealed partial class SpectreGear : UserControl
    {
        public string LightLevel
        {
            get { return GetValue(LightLevelProperty) as string; }
            set { SetValue(LightLevelProperty, value); }
        }
        public static readonly DependencyProperty LightLevelProperty =
            DependencyProperty.Register("LightLevel", typeof(string), typeof(SpectreGear), new PropertyMetadata(""));
        public string GrimoireLevel
        {
            get { return GetValue(GrimoireLevelProperty) as string; }
            set { SetValue(GrimoireLevelProperty, value); }
        }
        public static readonly DependencyProperty GrimoireLevelProperty =
            DependencyProperty.Register("GrimoireLevel", typeof(string), typeof(SpectreGear), new PropertyMetadata(""));
        public string IntellectLevel
        {
            get { return GetValue(IntellectLevelProperty) as string; }
            set { SetValue(IntellectLevelProperty, value); }
        }
        public static readonly DependencyProperty IntellectLevelProperty =
            DependencyProperty.Register("IntellectLevel", typeof(string), typeof(SpectreGear), new PropertyMetadata(""));
        public string DisciplineLevel
        {
            get { return GetValue(DisciplineLevelProperty) as string; }
            set { SetValue(DisciplineLevelProperty, value); }
        }
        public static readonly DependencyProperty DisciplineLevelProperty =
            DependencyProperty.Register("DisciplineLevel", typeof(string), typeof(SpectreGear), new PropertyMetadata(""));

        public string StrengthLevel
        {
            get { return GetValue(StrengthLevelProperty) as string; }
            set { SetValue(StrengthLevelProperty, value); }
        }
        public static readonly DependencyProperty StrengthLevelProperty =
            DependencyProperty.Register("StrengthLevel", typeof(string), typeof(SpectreGear), new PropertyMetadata(""));

        public string SubclassName
        {
            get { return GetValue(SubclassNameProperty) as string; }
            set { SetValue(SubclassNameProperty, value); }
        }
        public static readonly DependencyProperty SubclassNameProperty =
            DependencyProperty.Register("SubclassName", typeof(string), typeof(SpectreGear), new PropertyMetadata(""));

        public ImageSource SubclassImage
        {
            get { return GetValue(SubclassImageProperty) as ImageSource; }
            set { SetValue(SubclassImageProperty, value); }
        }
        public static readonly DependencyProperty SubclassImageProperty =
            DependencyProperty.Register("SubclassImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));

        public ImageSource PrimaryImage
        {
            get { return GetValue(PrimaryImageProperty) as ImageSource; }
            set { SetValue(PrimaryImageProperty, value); }
        }
        public static readonly DependencyProperty PrimaryImageProperty =
            DependencyProperty.Register("PrimaryImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource SecondaryImage
        {
            get { return GetValue(SecondaryImageProperty) as ImageSource; }
            set { SetValue(SecondaryImageProperty, value); }
        }
        public static readonly DependencyProperty SecondaryImageProperty =
            DependencyProperty.Register("SecondaryImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource HeavyImage
        {
            get { return GetValue(HeavyImageProperty) as ImageSource; }
            set { SetValue(HeavyImageProperty, value); }
        }
        public static readonly DependencyProperty HeavyImageProperty =
            DependencyProperty.Register("HeavyImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource GhostImage
        {
            get { return GetValue(GhostImageProperty) as ImageSource; }
            set { SetValue(GhostImageProperty, value); }
        }
        public static readonly DependencyProperty GhostImageProperty =
            DependencyProperty.Register("GhostImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource HelmetImage
        {
            get { return GetValue(HelmetImageProperty) as ImageSource; }
            set { SetValue(HelmetImageProperty, value); }
        }
        public static readonly DependencyProperty HelmetImageProperty =
            DependencyProperty.Register("HelmetImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource GauntletsImage
        {
            get { return GetValue(GauntletsImageProperty) as ImageSource; }
            set { SetValue(GauntletsImageProperty, value); }
        }
        public static readonly DependencyProperty GauntletsImageProperty =
            DependencyProperty.Register("GauntletsImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource ChestArmorImage
        {
            get { return GetValue(ChestArmorImageProperty) as ImageSource; }
            set { SetValue(ChestArmorImageProperty, value); }
        }
        public static readonly DependencyProperty ChestArmorImageProperty =
            DependencyProperty.Register("ChestArmorImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource BootsImage
        {
            get { return GetValue(BootsImageProperty) as ImageSource; }
            set { SetValue(BootsImageProperty, value); }
        }
        public static readonly DependencyProperty BootsImageProperty =
            DependencyProperty.Register("BootsImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource ClassItemImage
        {
            get { return GetValue(ClassItemImageProperty) as ImageSource; }
            set { SetValue(ClassItemImageProperty, value); }
        }
        public static readonly DependencyProperty ClassItemImageProperty =
            DependencyProperty.Register("ClassItemImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));
        public ImageSource ArtifactImage
        {
            get { return GetValue(ArtifactImageProperty) as ImageSource; }
            set { SetValue(ArtifactImageProperty, value); }
        }
        public static readonly DependencyProperty ArtifactImageProperty =
            DependencyProperty.Register("ArtifactImage", typeof(ImageSource), typeof(SpectreGear), new PropertyMetadata(""));

        public SpectreGear()
        {
            InitializeComponent();
            Main.DataContext = this;
        }
    }
}
