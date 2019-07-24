using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Repository
{
    public enum CardSuit { Clubs, Diamonds, Hearts, Spades }

    public struct Card
    {
        public CardSuit Suit { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            string name;
            switch (Value)
            {
                case 1:
                    name = "Ace";
                    break;
                case 11:
                    name = "Jack";
                    break;
                case 12:
                    name = "Queen";
                    break;
                case 13:
                    name = "King";
                    break;
                default:
                    name = Value.ToString();
                    break;
            }

            return $"{name} of {Suit}";
        }
    }
}
