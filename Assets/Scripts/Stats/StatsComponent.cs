using System.Collections.Generic;

namespace Stats
{
    public class StatsComponent
    {
        public Dictionary<StatType, BaseStats> Stats = new();

        private List<IStatModifier> activeModifiers = new();

        public void AddStat(BaseStats stat)
        {
            Stats[stat.statType] = stat;
        }

        public void ApplyModifier(IStatModifier modifier)
        {
            activeModifiers.Add(modifier);
            foreach (var stat in Stats.Values)
            {
                modifier.Apply(stat);
            }
        }

        public void RemoveModifier(IStatModifier modifier)
        {
            activeModifiers.Remove(modifier);
            // Optionally re-calculate stats
        }

        public float GetStatValue(StatType type)
        {
            return Stats.TryGetValue(type, out var stat) ? stat.currentValue : 0f;
        }

        public void UpgradeStat(UpgradeModifier upgrade)
        {
            ApplyModifier(upgrade);
        }

        public void ApplyBuff(BuffModifier buff)
        {
            ApplyModifier(buff);
            // Có thể dùng Coroutine để tự động Remove sau Duration nếu dùng Unity MonoBehaviour
        }

        public void ScaleEnemyStat(WaveScalingModifier scaling)
        {
            ApplyModifier(scaling);
        }
    }
}