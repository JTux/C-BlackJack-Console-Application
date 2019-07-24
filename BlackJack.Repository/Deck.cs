using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Repository
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = CreateNewDeck();
        }

        public Card DrawCard()
        {
            var card = Cards.First();
            Cards.Remove(card);
            return card;
        }

        private List<Card> GetFreshSuit(CardSuit suit)
        {
            var cards = new List<Card>();

            for (int i = 1; i < 14; i++)
                cards.Add(new Card { Suit = suit, Value = i });

            return cards;
        }

        private List<Card> CreateNewDeck()
        {
            var deck = new List<Card>();
            for (int i = 0; i < 4; i++)
                deck.AddRange(GetFreshSuit((CardSuit)i));

            return deck;
        }
    }

}
