using Sirenix.OdinInspector;
using Stats;
using Units.Config;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
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
    public interface IUpgradeStats
    {
        void UpgradeStats(ListStats stats);
    }
    public class AdditionStats : IUpgradeStats
    {
        private ListStats additionStats;
        public AdditionStats(ListStats additionStats)
        {
            this.additionStats = additionStats;
        }
        public void UpgradeStats(ListStats stats)
        {

        }
    }
    public class MultiplyStats : IUpgradeStats
    {
        private ListStats multiplyStats;
        public MultiplyStats(ListStats additionStats)
        {
            this.multiplyStats = additionStats;
        }
        public void UpgradeStats(ListStats stats)
        {

        }
    }
}
