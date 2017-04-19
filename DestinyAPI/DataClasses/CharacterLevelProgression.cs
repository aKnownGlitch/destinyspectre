namespace DestinyAPI
{
    public class CharacterLevelProgression
    {
        public long dailyProgress { get; set; }
        public long weeklyProgress { get; set; }
        public long currentProgress { get; set; }
        public int level { get; set; }
        public int step { get; set; }
        public long progressToNextLevel { get; set; }
        public long nextLevelAt { get; set; }
        public long progressHash { get; set; }
    }

}
