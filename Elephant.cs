using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Elephant : Animal
    {

        public Elephant() : base("Elephant", 15) { }
        public override Shit Shit()
        {
            return new Shit(6);
        }
    }
}
