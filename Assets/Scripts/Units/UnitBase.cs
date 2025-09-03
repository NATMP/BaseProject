using Stats;
using Units.Config;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase
{
    protected string unitName;
    protected List<BaseStats> stats;
    protected Dictionary<StatType, BaseStats> StatsLookup { get; private set; }
    public SOUnitConfig SOUnitConfig { get => soUnitConfig; }

    protected SOUnitConfig soUnitConfig;

    public BaseStats this[StatType type] => GetStat(type);

    public virtual void OnCreate(SOUnitConfig config)
    {
        unitName = config.UnitName;
        soUnitConfig = config;
        stats = new List<BaseStats>();
        StatsLookup = new Dictionary<StatType, BaseStats>();
        foreach (var stat in config.StatsList)
        {
            var clonedStat = stat.Clone();
            stats.Add(clonedStat);
            StatsLookup[clonedStat.statType] = clonedStat;
        }
    }

    public BaseStats GetStat(StatType type)
    {
        StatsLookup.TryGetValue(type, out var stat);
        return stat;
    }
}
