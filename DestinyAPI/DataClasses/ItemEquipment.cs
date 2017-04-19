using System.Collections.Generic;

namespace DestinyAPI
{
    public class ItemEquipment
    {
        public long weaponSandboxPatternIndex { get; set; }
        public long gearArtArrangementIndex { get; set; }
        public List<Dye> defaultDyes { get; set; }
        public List<Dye> lockedDyes { get; set; }
        public List<Dye> customDyes { get; set; }
        public CustomDyeExpression customDyeExpression { get; set; }
        public long weaponPatternHash { get; set; }
        public List<Arrangement> arrangements { get; set; }
        public long equipmentSlotHash { get; set; }
    }
}
