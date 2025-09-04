using System;
using System.Collections.Generic;
using UnityEngine;
using Stats;
using Sirenix.OdinInspector;

namespace Units.Config
{
    [CreateAssetMenu(menuName = "Data/UnitSO/Unit Config")]
    public class SOUnitConfig : ScriptableObject
    {
        public string UnitName;
        public string PrefabAddr;
        public string TakeDmgVFXAddr;
        public string DieVFXAddr;
        public UnitType UnitType;
        public TeamType TeamType;
        [TableList] public ListStats StatsList;
    }
    public enum UnitType
    {
        Wagon,
        City,
        HeadTrain,
        Enemy_Base,
        Enemy_Stronger,
        Enemy_Fast,
        Enemy_Distance,
        Enemy_Splitting,
        Enemy_Exploding,
        Enemy_StrongElite,
        Enemy_SummonerElite,
        EnemyBoss_Big,
        EnemyBoss_Blocking,
        EnemyBoss_BigSplitting,
        Enemy_Mini,
        Enemy_MiniSummon,
        EnemyBoss_MiniSplitting,
        Building,
    }
    public enum TeamType
    {
        Player,
        Enemy,
        Neutral
    }
}