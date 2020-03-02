using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Giraffe : Animal
    {
        public Giraffe() : base("Giraffe", 6) { }
        public override Shit Shit()
        {
            return new Shit(4);
        }
    }
}
