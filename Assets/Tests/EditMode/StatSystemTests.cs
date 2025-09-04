//using NUnit.Framework;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.TestTools;
//using static UnityEditorInternal.VersionControl.ListControl;

//public class StatSystemTests
//{
//    [Test]
//    public void UpgradeModifier_AddsValueToStat()
//    {
//        var stat = new BaseStats { statType = StatType.HP, initValue = 100, currentValue = 100 };
//        var listStats = new ListStats();
//        listStats.stats.Add(stat);

//        var upgradeCard = ScriptableObject.CreateInstance<SOCardConfig>();
//        upgradeCard.targetStat = StatType.HP;
//        upgradeCard.buffType = BuffType.Add;
//        upgradeCard.buffValue = 50;

//        var upgradeFactory = new AddModifierFactory();
//        var upgradeModifier = upgradeFactory.CreateModifier(upgradeCard);
//        listStats.ApplyUpgrade(upgradeModifier);

//        Assert.AreEqual(150, listStats.stats[0].currentValue);
//    }

//    [Test]
//    public void BuffModifier_MultipliesStat()
//    {
//        var stat = new BaseStats { statType = StatType.HP, initValue = 100, currentValue = 100 };
//        var listStats = new ListStats();
//        listStats.stats.Add(stat);

//        var buffCard = ScriptableObject.CreateInstance<SOCardConfig>();
//        buffCard.targetStat = StatType.HP;
//        buffCard.buffType = BuffType.Multiply;
//        buffCard.buffValue = 2f;

//        var buffFactory = new MultiplyModifierFactory();
//        var buffModifier = buffFactory.CreateModifier(buffCard);
//        listStats.ApplyBuff(buffModifier);

//        Assert.AreEqual(200, listStats.stats[0].currentValue);
//    }

//    [Test]
//    public void RemoveBuffModifier_RestoresStat()
//    {
//        var stat = new BaseStats { statType = StatType.HP, initValue = 100, currentValue = 100 };
//        var listStats = new ListStats();
//        listStats.stats.Add(stat);

//        var buffCard = ScriptableObject.CreateInstance<SOCardConfig>();
//        buffCard.targetStat = StatType.HP;
//        buffCard.buffType = BuffType.Multiply;
//        buffCard.buffValue = 2f;

//        var buffFactory = new MultiplyModifierFactory();
//        var buffModifier = buffFactory.CreateModifier(buffCard);
//        listStats.ApplyBuff(buffModifier);

//        listStats.RemoveBuff(buffModifier);

//        Assert.AreEqual(100, listStats.stats[0].currentValue);
//    }
//}
