using System;
using System.Collections.Generic;
using UnityEngine;

namespace Units.Config
{
    [CreateAssetMenu(menuName = "Data/UnitSO/Enemy Unit Config")]
    public class SOEnemyUnitConfig : SOUnitConfig
    {
        public EnemyType EnemyType;
        public int EXP;
        private void OnEnable()
        {
            TeamType = TeamType.Enemy;
        }
    }
    public enum EnemyType
    {
        Common,
        Rare,
        Elite,
        Boss
    }
}
