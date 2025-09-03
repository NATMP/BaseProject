namespace CardSystem
{
    public interface ICardBuffStrategy
    {
        void Apply(Stats.BaseStats stat, float value);
    }
}
