namespace Stats
{
    public class MultiplyPercentModifier : IStatModifier
    {
        public StatType TargetStat;
        public float BuffMultiplier;
        private bool applied = false;
        public void Apply(BaseStats stat)
        {
            if (!applied && stat.statType == TargetStat)
            {
                stat.MultiplicationStat(1 + BuffMultiplier / 100f);
                applied = true;
            }
        }
        public void Remove(BaseStats stat)
        {
            if (applied && stat.statType == TargetStat)
            {
                stat.DivisionStat(1 + BuffMultiplier / 100f);
                applied = false;
            }
        }
    }
}
