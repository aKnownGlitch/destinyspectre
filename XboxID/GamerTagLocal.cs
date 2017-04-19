using System.Threading.Tasks;

namespace XboxID
{
    public static class GamerTagLocal
    {
        public static async Task<string> Get()
        {
            Windows.Storage.ApplicationDataContainer localSettings =
                Windows.Storage.ApplicationData.Current.LocalSettings;

            var thisUser = await User.Get();

            var user = localSettings.Values["User"];
            if ((thisUser != null) && (user != null) && (thisUser == user.ToString()))
            {
                var value = localSettings.Values["GamerTag"];
                if (value != null)
                {
                    return value.ToString();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static async Task Put(string GamerTag)
        {
            Windows.Storage.ApplicationDataContainer localSettings =
                Windows.Storage.ApplicationData.Current.LocalSettings;
            var thisUser = await User.Get();
            localSettings.Values["User"] = thisUser;
            localSettings.Values["GamerTag"] = GamerTag;
        }
    }
}
