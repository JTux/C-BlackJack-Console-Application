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
        public string Name { get; protected set; }

        public Person() => Hand = new Hand();
    }
}
