using Stats;
using Units.Config;

public abstract class UnitBase
{
    protected string unitName;
    protected ListStats stats;
    protected SOUnitConfig soUnitConfig;
    public SOUnitConfig SOUnitConfig { get; private set; }
    public ListStats Stats => stats;

    public virtual void OnCreate(SOUnitConfig config)
    {
        SOUnitConfig = config;
        unitName = config.UnitName;
        stats = config.StatsList.Clone();
        stats.Init();
    }
}
