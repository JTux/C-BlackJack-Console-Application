using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Repository
{
    public class Hand
    {
        private readonly List<Card> _cards;
        public int TotalValue => GetHandValue(true);
        public int PublicValue => GetHandValue(false);

        public Hand()
        {
            _cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void AddFaceDownCard(Card card)
        {
            card.IsFaceDown = true;
            _cards.Add(card);
        }

        public List<Card> GetHand()
        {
            return _cards;
        }

        private int GetHandValue(bool includeAllCards)
        {
            var handValue = 0;

            var totalAces = _cards.Where(c => c.Value == 1).Count();

            var cards = (includeAllCards) ? _cards : _cards.Where(c => c.IsFaceDown == false);

            foreach (var card in cards)
                if (card.Value > 9)
                    handValue += 10;
                else
                    handValue += card.Value;

            for (int i = 0; i < totalAces; i++)
                if (handValue + 10 <= 21)
                    handValue += 10;

            return handValue;
        }
    }

}
