using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace XboxID
{
    public static class User
    {
        public static async Task<string> Get()
        {
            var users = await Windows.System.User.FindAllAsync();
            var current = users.Where(p => p.AuthenticationStatus == UserAuthenticationStatus.LocallyAuthenticated &&
                            p.Type == UserType.LocalUser).FirstOrDefault();
            String[] desiredProperties = new String[]
                    {
                        KnownUserProperties.FirstName,
                        KnownUserProperties.LastName,
                        KnownUserProperties.DisplayName,
                        KnownUserProperties.AccountName
                    };
            var values = await current.GetPropertiesAsync(desiredProperties);
            var account = values[KnownUserProperties.AccountName.ToString()].ToString();
            var displayName = values[KnownUserProperties.DisplayName.ToString()].ToString();
            var lastName = values[KnownUserProperties.LastName.ToString()].ToString();
            var firstName = values[KnownUserProperties.FirstName.ToString()].ToString();
            if(!string.IsNullOrEmpty(account))
            {
                return account;
            }
            else
            {
                if (!string.IsNullOrEmpty(displayName))
                {
                    return displayName;
                }
                else
                {
                    return firstName + " " + lastName;
                }
            }
        }
    }
}
