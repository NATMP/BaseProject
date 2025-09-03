using System.Collections.Generic;
using UnityEngine;
using Units;

namespace CardSystem
{
    public class CardManager : MonoBehaviour
    {
        private readonly Dictionary<BuffType, ICardBuffStrategy> _buffStrategies =
            new Dictionary<BuffType, ICardBuffStrategy>
            {
                { BuffType.Add, new AddBuffStrategy() },
                { BuffType.Multiply, new MultiplyBuffStrategy() },
                { BuffType.Override, new OverrideBuffStrategy() }
            };

        [SerializeField] private List<SOCardConfig> allCards;
        private List<SOCardConfig> selectedCards = new();

        public SOCardConfig ChooseCard()
        {
            // Example: random pick, you can implement UI selection
            var card = allCards[Random.Range(0, allCards.Count)];
            selectedCards.Add(card);
            return card;
        }

        public void ApplyCardBuff(SOCardConfig card, UnitBase unit)
        {
            var stat = unit[card.targetStat];
            if (stat == null) return;

            if (_buffStrategies.TryGetValue(card.buffType, out var strategy))
            {
                strategy.Apply(stat, card.buffValue);
            }
        }
    }
}
