using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using XboxID;

namespace DestinyViewModel
{
    public class Destiny : BindableBase<DestinyAPI.Destiny>
    {
        public Destiny() : base()
        {
        }

        public async Task GetPlayer()
        {
            DisplayName = await GamerTag.Get();
        }

        private string _displayName = string.Empty;
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (value != _displayName)
                {
                    _displayName = value;
                    RaisePropertyChanged("DisplayName");
                }
            }
        }

        public delegate void CharactersLoadedEventHandler(object sender, EventArgs e);
        public event CharactersLoadedEventHandler CharactersLoaded;
        public async Task GetCharacters()
        {
            await This.GetPlayer(DisplayName);
            TransferMember();
            CharactersLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void TransferMember()
        {
            if (This.Member != null)
            {
                MemberIcon = new BitmapImage(new Uri("https://bungie.net" + This.Member.iconPath, UriKind.Absolute));
                if (This.CharacterData != null)
                {
                    _characters.Clear();
                    foreach (var c in This.CharacterData.characters)
                    {
                        _characters.Add(new DestinyCharacter(c));
                    }
                    RaisePropertyChanged("Characters");
                }
            }
        }

        private ImageSource _memberIcon = null;
        public ImageSource MemberIcon
        {
            get { return _memberIcon; }
            private set
            {
                if (value != _memberIcon)
                {
                    _memberIcon = value;
                    RaisePropertyChanged("MemberIcon");
                }
            }
        }

        private ObservableCollection<DestinyCharacter> _characters = new ObservableCollection<DestinyCharacter>();
        public ObservableCollection<DestinyCharacter> Characters
        {
            get { return _characters; }
        }
    }
}
