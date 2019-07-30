using BlackJack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                var dealer = new Dealer();

                var game = new Game(dealer);
                game.InitializeDeck(6);
                var people = new List<Person>
                    {
                        new Player("Joshua"),
                        new Player("Lawrence"),
                        new Player("Marty")
                    };
                game.AddPlayers(people);

                while (true)
                {
                    Console.Clear();
                    game.StartNewRound();
                    game.DealCards();

                    Console.WriteLine();

                    game.DisplayPoints();

                    Console.WriteLine($"\nCards left: {dealer.AllCards.Count}\nUsed cards: {dealer.DiscardPile.Count}");

                    Console.ReadKey();
                }
            }
        }
    }
}
