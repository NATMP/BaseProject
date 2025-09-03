namespace CardSystem
{
    public class OverrideBuffStrategy : ICardBuffStrategy
    {
        public void Apply(Stats.BaseStats stat, float value)
        {
            stat.currentValue = value;
        }
    }
}
