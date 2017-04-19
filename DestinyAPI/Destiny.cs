using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinyAPI
{
    public class Destiny
    {
        public Membership Member { get; private set; }
        public Characters CharacterData { get; private set; }

        public Destiny()
        {
            Member = new Membership() { displayName = "Unknown" };
        }

        public async Task GetPlayer(string GamerTag)
        {
            Member = await MembershipAPI.Get(GamerTag);
            CharacterData = await CharactersAPI.Get(Member.membershipId);
        }
    }
}
