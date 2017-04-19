namespace DestinyAPI
{
    public class CharacterBase
    {
        public string membershipId { get; set; }
        public int membershipType { get; set; }
        public string characterId { get; set; }
        public string dateLastPlayer { get; set; }
        public string minutesPlayedThisSession { get; set; }
        public string minutesPlayerTotal { get; set; }
        public long powerLevel { get; set; }
        public long raceHash { get; set; }
        public long genderHas { get; set; }
        public long classHash { get; set; }
        public long currentActivityHash { get; set; }
        public long lastCompletedStory { get; set; }
        public CharacterStats stats { get; set; }
        public Customization customization { get; set; }
        public long grimoireScore { get; set; }
        public PeerView peerView { get; set; }
        public int enderType { get; set; }
        public int classType { get; set; }
        public long buildStatGroupHash { get; set; }
    }
}
