using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemyUnit : UnitBase
{
    [TypeFilter(typeof(IUpgradeStats))]
    [SerializeField] protected SerializableType upgradeType;
}
