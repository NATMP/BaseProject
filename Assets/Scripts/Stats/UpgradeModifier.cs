namespace Stats
{
    public class UpgradeModifier : IStatModifier
    {
        public StatType TargetStat;
        public float UpgradeValue;

        public void Apply(BaseStats stat)
        {
            if (stat.statType == TargetStat)
                stat.AdditionStat(UpgradeValue);
        }

        public void Remove(BaseStats stat)
        {
            if (stat.statType == TargetStat)
                stat.SubtractionStat(UpgradeValue);
        }
    }
}
