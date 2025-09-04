using CardSystem;

namespace Stats
{
    public class MultiplyModifierFactory : IStatModifierFactory
    {
        public IStatModifier CreateModifier(SOCardConfig card)
        {
            return new MultiplyModifier { TargetStat = card.targetStat, BuffMultiplier = card.buffValue };
        }
    }
}