using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinyAPI
{
    public static class MembershipAPI
    {
        public static async Task<Membership> Get(string GamerTag)
        {
            var data = await BungieAPI.Get("/SearchDestinyPlayer/1/" + GamerTag + "/ ");
            if (data != null)
            {
                var membership = data.Parent.ToObject<Membership>();
                return membership;
            }
            return null;
        }
    }
}
