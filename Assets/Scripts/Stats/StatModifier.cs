namespace Stats
{
    public class StatModifier : IStatModifier
    {
        public enum ModifierType { Add, Multiply, Override }
        public ModifierType Type;
        public float Value;

        public void Apply(BaseStats stat)
        {
            switch (Type)
            {
                case ModifierType.Add:
                    stat.AdditionStat(Value);
                    break;
                case ModifierType.Multiply:
                    stat.MultiplicationStat(Value);
                    break;
                case ModifierType.Override:
                    stat.currentValue = Value;
                    break;
            }
        }

        public void Remove(BaseStats stat)
        {
            // Implement reverse logic if needed
        }
    }
}