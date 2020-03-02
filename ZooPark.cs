using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class ZooPark
    {
        List<AnimalContainer> animals;
        public List<AnimalContainer> Animals
        {
            get { return animals; }
        }
        public ZooPark(List<AnimalContainer> animals)
        {
            this.animals = animals;
        }
    }
}
