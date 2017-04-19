namespace DestinyViewModel
{
    public class ExtendedAttributes : BindableBase
    {
        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                SetProperty(ref _IsSelected, value, "IsSelected");
            }
        }
    }
}