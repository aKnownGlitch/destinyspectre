using Windows.UI.Xaml.Controls;

namespace DestinySpectre
{
    public sealed partial class MainPage : Page
    {
        private DestinyViewModel.Destiny data = new DestinyViewModel.Destiny();
        public MainPage()
        {
            InitializeComponent();
            DataContext = data;
            data.CharactersLoaded += Data_CharactersLoaded;
        }

        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await data.GetPlayer();
            await data.GetCharacters();
        }

        private async void Data_CharactersLoaded(object sender, System.EventArgs e)
        {
            CharacterList.SelectedIndex = 0;
            data.Characters[0].InventoryLoaded += MainPage_InventoryLoaded;
            foreach (var c in data.Characters)
            {
                await c.GetInventory();
            }
        }

        private void MainPage_InventoryLoaded(object sender, System.EventArgs e)
        {
            GearWait.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            GearControl.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void SelectedCharacter_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            CharacterSelection.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void CharacterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CharacterSelection.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void CharacterList_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            CharacterSelection.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
