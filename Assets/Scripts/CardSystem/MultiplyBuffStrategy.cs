namespace CardSystem
{
    public class MultiplyBuffStrategy : ICardBuffStrategy
    {
        public void Apply(Stats.BaseStats stat, float value)
        {
            stat.MultiplicationStat(value);
        }
    }
}
