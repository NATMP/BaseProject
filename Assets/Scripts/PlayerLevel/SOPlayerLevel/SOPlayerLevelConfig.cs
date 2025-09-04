using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLevel
{
    [CreateAssetMenu(menuName = "Data/PlayerLevelSO/Player Level Config")]
    public class SOPlayerLevelConfig : ScriptableObject
    {
        [TableList] public List<InfoLevel> Levels;
    }
    [Serializable]
    public class InfoLevel
    {
        public int Level;
        public int ExpToLevelUp;
    }
}
