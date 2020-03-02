using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Park
    {
        List<AnimalContainer> animals;
        public List<AnimalContainer> Animals
        {
            get { return animals; }
        }
        public Park(List<AnimalContainer> animals)
        {
            this.animals = animals;
        }
    }
}
