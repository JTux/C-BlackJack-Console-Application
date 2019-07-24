using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Repository
{
    public abstract class Person
    {
        public Hand Hand { get; set; }
        public string Name { get; }

        public Person(string name)
        {
            Hand = new Hand();
            Name = name;
        }
    }
}
