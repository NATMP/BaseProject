using CardSystem;

namespace Stats
{
    public class AddModifierFactory : IStatModifierFactory
    {
        public IStatModifier CreateModifier(SOCardConfig card)
        {
            return new AddModifier { TargetStat = card.targetStat, UpgradeValue = card.buffValue };
        }
    }
}