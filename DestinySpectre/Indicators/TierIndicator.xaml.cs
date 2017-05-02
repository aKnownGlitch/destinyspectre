using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DestinySpectre
{
    public sealed partial class TierIndicator : UserControl
    {
        public enum TierType { Intellect, Discipline, Strength }

        public TierType Type
        {
            get { return (TierType)GetValue(TierTypeProperty); }
            set
            {
                SetValue(TierTypeProperty, value);
                if(value == TierType.Discipline)
                {
                    DisciplineImage.Visibility = Visibility.Visible;
                    IntellectImage.Visibility = Visibility.Collapsed;
                    StrengthImage.Visibility = Visibility.Collapsed;
                }
                if (value == TierType.Intellect)
                {
                    IntellectImage.Visibility = Visibility.Visible;
                    DisciplineImage.Visibility = Visibility.Collapsed;
                    StrengthImage.Visibility = Visibility.Collapsed;
                }
                if (value == TierType.Strength)
                {
                    StrengthImage.Visibility = Visibility.Visible;
                    IntellectImage.Visibility = Visibility.Collapsed;
                    DisciplineImage.Visibility = Visibility.Collapsed;
                }
            }
        }
        public static readonly DependencyProperty TierTypeProperty =
            DependencyProperty.Register("TierType", typeof(TierType), typeof(TierIndicator), new PropertyMetadata(TierType.Intellect));

        public string Level
        {
            get { return (string)GetValue(LevelProperty); }
            set
            {
                SetValue(LevelProperty, value);
            }
        }
        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register("Level", typeof(string), typeof(TierIndicator), new PropertyMetadata("0"));

        public Visibility TierVisibility
        {
            get { return (Visibility)GetValue(TierVisibilityProperty); }
            set { SetValue(TierVisibilityProperty, value); }
        }
        public static readonly DependencyProperty TierVisibilityProperty =
            DependencyProperty.Register("TierVisibility", typeof(Visibility), typeof(TierIndicator), new PropertyMetadata(Visibility.Collapsed));

        public TierIndicator()
        {
            this.InitializeComponent();
            this.Main.DataContext = this;
        }
    }
}
