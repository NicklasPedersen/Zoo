using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    abstract class DogLike : Animal
    {
        public DogLike(string name) : base(name, 4) { }
        public override Shit Shit()
        {
            return new Shit(2);
        }
    }
}
