using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class BaseStats
    {
        public StatType statType;
        public float initValue;
        public float currentValue;

        #region +-*/pow

        public void MultiplicationStat(float value)
        {
            initValue = initValue * value;
            currentValue = currentValue * value;
        }

        public void SubtractionStat(float value)
        {
            initValue = initValue - value;
            currentValue = currentValue - value;
        }

        public void DivisionStat(float value)
        {
            initValue = initValue / value;
            currentValue = currentValue / value;
        }

        public void AdditionStat(float value)
        {
            initValue = initValue + value;
            currentValue = currentValue + value;
        }
        public void PowStat(float value)
        {
            initValue = Mathf.Pow(initValue, value);
            currentValue = Mathf.Pow(currentValue, value);
        }

        #endregion

        public BaseStats Clone()
        {
            var clone = new BaseStats
            {
                statType = statType,
                initValue = initValue,
                currentValue = currentValue
            };
            return clone;
        }
        public void Init()
        {
            currentValue = initValue;
        }
    }
    public enum StatType
    {
        HP,
        Atk,
        AtkRange,
        AS,
        MS,
        CD,
        DmgInterval,
        Exp,
        CritChance,
        CritDmg,
    }
}
