using BlackJack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();

            while (true)
            {
                Console.Clear();

                var dealer = new Dealer();

                for (int i = 0; i < 4; i++)
                    dealer.AddDeck();

                dealer.ShuffleAllCards();
                while (true)
                {
                    Console.Clear();
                    var playerOne = new Player("Joshua");
                    var playerTwo = new Player("Lawrence");
                    var playerThree = new Player("Grant");

                    dealer.Hand = new Hand();

                    var people = new List<Person>();
                    people.Add(playerOne);
                    people.Add(playerTwo);
                    people.Add(playerThree);
                    people.Add(dealer);

                    for (int i = 0; i < 2; i++)
                        foreach (var person in people)
                        {
                            person.Hand.AddCard(dealer.DealCard());
                            if (!(person is Dealer))
                                Console.WriteLine($"{person.Name} was given {person.Hand.GetHand()[i]}");
                        }

                    Console.WriteLine();

                    foreach(var person in people)
                        Console.WriteLine($"{person.Name} has {person.Hand.TotalValue} points");

                    Console.ReadKey();
                }
            }
        }
    }
}
