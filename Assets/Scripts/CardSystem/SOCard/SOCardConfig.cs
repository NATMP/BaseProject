using Stats;
using Units.Config;
using UnityEngine;

namespace CardSystem
{
    [CreateAssetMenu(menuName = "Data/Card Config")]
    public class SOCardConfig : ScriptableObject
    {
        public string cardName;
        public string description;
        public StatType targetStat;
        public float buffValue;
        public UnitType targetUnitType;
        public BuffType buffType;
    }
    public enum BuffType
    {
        Add,
        Multiply,
        Override,
        MultiplyPercent,
    }
}
