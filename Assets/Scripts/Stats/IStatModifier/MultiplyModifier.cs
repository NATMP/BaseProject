namespace Stats
{
    public class MultiplyModifier : IStatModifier
    {
        public StatType TargetStat;
        public float BuffMultiplier;
        private bool applied = false;

        public void Apply(BaseStats stat)
        {
            if (!applied && stat.statType == TargetStat)
            {
                stat.MultiplicationStat(BuffMultiplier);
                applied = true;
            }
        }

        public void Remove(BaseStats stat)
        {
            if (applied && stat.statType == TargetStat)
            {
                stat.DivisionStat(BuffMultiplier);
                applied = false;
            }
        }
    }
}
