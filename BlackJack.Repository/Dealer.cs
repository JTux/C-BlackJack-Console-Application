using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Repository
{
    public class Dealer : Person
    {
        private readonly List<Deck> _decks;
        private readonly Random _rand;

        public List<Card> AllCards { get; private set; }

        public Dealer() : base("Dealer")
        {
            _rand = new Random();
            _decks = new List<Deck>();
            AllCards = new List<Card>();
        }

        public void AddDeck() => _decks.Add(new Deck());
        public void RemoveDeck() => _decks.RemoveAt(_decks.Count - 1);

        public Card DealCard()
        {
            if (AllCards.FirstOrDefault().Value == 0)
                ShuffleAllCards();

            var card = AllCards.FirstOrDefault();

            AllCards.Remove(card);
            return card;
        }

        public void ShuffleAllCards()
        {
            var allCards = CombineAllDecks();
            AllCards = ShuffleDeck(allCards);
        }

        private List<Card> CombineAllDecks()
        {
            var allCards = new List<Card>();

            foreach (var deck in _decks)
                allCards.AddRange(deck.Cards);

            return allCards;
        }

        private List<Card> ShuffleDeck(List<Card> deck)
        {
            var shuffledDeck = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                shuffledDeck = new List<Card>();
                var initialCardCount = deck.Count;

                for (int j = 0; j < initialCardCount; j++)
                {
                    var card = deck[_rand.Next(0, deck.Count)];
                    deck.Remove(card);
                    shuffledDeck.Add(card);
                }

                deck = shuffledDeck;
            }
            return shuffledDeck;
        }
    }
}
