namespace CardSystem
{
    public class AddBuffStrategy : ICardBuffStrategy
    {
        public void Apply(Stats.BaseStats stat, float value)
        {
            stat.AdditionStat(value);
        }
    }
}
