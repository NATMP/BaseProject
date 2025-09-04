using CardSystem;

namespace Stats
{
    public class MultiplyPercentModifierFactory : IStatModifierFactory
    {
        public IStatModifier CreateModifier(SOCardConfig card)
        {
            return new MultiplyPercentModifier { TargetStat = card.targetStat, BuffMultiplier = card.buffValue };
        }
    }
}
