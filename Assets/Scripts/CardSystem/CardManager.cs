using System.Collections.Generic;
using UnityEngine;
using Units;
using Stats;

namespace CardSystem
{
    public class CardManager : MonoBehaviour
    {
        private readonly Dictionary<BuffType, IStatModifierFactory> _buffModifierFactories =
            new Dictionary<BuffType, IStatModifierFactory>
            {
                { BuffType.Add, new AddModifierFactory() },
                { BuffType.Multiply, new MultiplyModifierFactory() },
                { BuffType.MultiplyPercent, new MultiplyPercentModifierFactory() }
            };

        [SerializeField] private List<SOCardConfig> allCards;
        private List<SOCardConfig> selectedCards = new();

        public SOCardConfig ChooseCard()
        {
            var card = allCards[Random.Range(0, allCards.Count)];
            selectedCards.Add(card);
            return card;
        }

        public void ApplyCardBuff(SOCardConfig card, UnitBase unit)
        {
            if (_buffModifierFactories.TryGetValue(card.buffType, out var factory))
            {
                var modifier = factory.CreateModifier(card);
                unit.Stats.ApplyBuff(modifier);
            }
        }
    }
}
