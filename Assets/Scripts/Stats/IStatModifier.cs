namespace Stats
{
    public interface IStatModifier
    {
        void Apply(BaseStats stat);
        void Remove(BaseStats stat);
    }
}