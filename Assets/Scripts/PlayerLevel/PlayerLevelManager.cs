using UnityEngine;
using System.Collections.Generic;
using CardSystem;
using Units.Config;

namespace PlayerLevel
{
    public class PlayerLevelManager : MonoBehaviour
    {
        [SerializeField] private SOPlayerLevelConfig levelConfig;
        [SerializeField] private CardManager cardManager;
        [SerializeField] private List<UnitBase> allUnits;
        public int CurrentLevel { get; private set; } = 1;
        public int CurrentExp { get; private set; } = 0;

        public void AddExp(int amount)
        {
            CurrentExp += amount;
            TryLevelUp();
        }

        private void TryLevelUp()
        {
            while (CurrentLevel < levelConfig.Levels.Count &&
                   CurrentExp >= levelConfig.Levels[CurrentLevel - 1].ExpToLevelUp)
            {
                CurrentExp -= levelConfig.Levels[CurrentLevel - 1].ExpToLevelUp;
                CurrentLevel++;
                // Chọn thẻ bài và apply buff
                var card = cardManager.ChooseCard();
                foreach (var unit in allUnits)
                {
                    if (unit.SOUnitConfig.UnitType == card.targetUnitType)
                        cardManager.ApplyCardBuff(card, unit);
                }
            }
        }

        public int GetExpToNextLevel()
        {
            if (CurrentLevel < levelConfig.Levels.Count)
                return levelConfig.Levels[CurrentLevel - 1].ExpToLevelUp - CurrentExp;
            return 0;
        }
    }
}
