using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack.Repository
{
    public class Game
    {
        public Dealer Dealer { get; private set; }
        public List<Person> People { get; private set; }

        private int _deckCount;
        public int DeckCount
        {
            get => _deckCount;
            set
            {
                _deckCount = value;

                for (int i = 0; i < _deckCount; i++)
                    Dealer.AddDeck();
            }
        }

        public Game()
        {
            People = new List<Person>();
        }

        public Game(Dealer dealer) : this()
        {
            Dealer = dealer;
        }

        public void AddPlayers(List<Person> list)
        {
            People.AddRange(list);
            People.Add(Dealer);
        }

        public void InitializeDeck(int deckCount)
        {
            for (int i = 0; i < deckCount; i++)
                Dealer.AddDeck();

            Dealer.ShuffleAllCards();
        }

        public void StartNewRound()
        {
            foreach (var person in People)
            {
                person.Hand = new Hand();
            }
        }

        public void DealCards()
        {
            for (int i = 0; i < 2; i++)
                foreach (var person in People)
                {
                    if (person is Dealer && i == 0)
                        person.Hand.AddFaceDownCard(Dealer.DealCard());
                    else
                        person.Hand.AddCard(Dealer.DealCard());
                    Thread.Sleep(500);

                    Console.WriteLine($"{person.Name} was given {person.Hand.GetHand()[i]}");
                }
        }

        public void DisplayPoints()
        {
            foreach (var person in People)
            {
                int points;

                if (person is Dealer)
                    points = person.Hand.PublicValue;
                else
                    points = person.Hand.TotalValue;

                Console.WriteLine($"{person.Name} has {points} points");
            }
        }
    }
}
