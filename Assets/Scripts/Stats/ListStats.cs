using System;
using System.Collections.Generic;

namespace Stats
{
    [Serializable]
    public class ListStats
    {
        public List<BaseStats> stats = new List<BaseStats>();

        private readonly List<IStatModifier> upgradeModifiers = new();
        private readonly List<IStatModifier> buffModifiers = new();

        public BaseStats this[StatType type]
        {
            get { return stats.Find(s => s.statType == type); }
        }

        public void Init()
        {
            foreach (var stat in stats)
                stat.Init();
            Recalculate();
        }

        public void ApplyUpgrade(IStatModifier modifier)
        {
            upgradeModifiers.Add(modifier);
            Recalculate();
        }

        public void ApplyBuff(IStatModifier modifier)
        {
            buffModifiers.Add(modifier);
            Recalculate();
        }

        public void RemoveBuff(IStatModifier modifier)
        {
            buffModifiers.Remove(modifier);
            Recalculate();
        }

        public void Recalculate()
        {
            // Reset to base
            foreach (var stat in stats)
                stat.currentValue = stat.initValue;

            // Apply upgrades
            foreach (var mod in upgradeModifiers)
                foreach (var stat in stats)
                    mod.Apply(stat);

            // Apply buffs
            foreach (var mod in buffModifiers)
                foreach (var stat in stats)
                    mod.Apply(stat);
        }

        public ListStats Clone()
        {
            var clone = new ListStats();
            foreach (var stat in stats)
                clone.stats.Add(stat.Clone());
            return clone;
        }

        public void Clear()
        {
            stats.Clear();
            upgradeModifiers.Clear();
            buffModifiers.Clear();
        }
    }
}
