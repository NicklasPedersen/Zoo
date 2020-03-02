using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Rabbit : Animal
    {
        public Rabbit() : base("Rabbit", 50) { }
        public override Shit Shit()
        {
            return new Shit(10);
        }
    }
}
