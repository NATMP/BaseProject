namespace Stats
{
    public class WaveScalingModifier : IStatModifier
    {
        public int WaveNumber;
        public float ScalingFactor;

        public void Apply(BaseStats stat)
        {
            stat.MultiplicationStat(1f + ScalingFactor * WaveNumber);
        }

        public void Remove(BaseStats stat)
        {
            stat.DivisionStat(1f + ScalingFactor * WaveNumber);
        }
    }
}

