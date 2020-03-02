using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    class AnimalContainer : IShitContainer
    {
        public EventWaitHandle isWork = new EventWaitHandle(false, EventResetMode.AutoReset);
        public EventWaitHandle hasShit = new EventWaitHandle(false, EventResetMode.AutoReset);
        private List<Shit> shits;
        public List<Shit> Shits
        {
            get { return shits; }
        }
        public List<Animal> animals;
        public List<Animal> Animals
        {
            get { return animals; }
        }
        private string name;
        public string Name
        {
            get { return name; }
        }
        public AnimalContainer(string name)
        {
            shits = new List<Shit>();
            animals = new List<Animal>();
            this.name = name;
        }
        public void PlaceAnimal(Animal animal)
        {
            animal.ShitContainer = this;
            animals.Add(animal);
        }

        public void PlaceShit(Shit shit)
        {
            lock (shits)
            {
                shits.Add(shit);
            }
            hasShit.Set();
            isWork.Set();
        }

        public Shit RemoveShit()
        {
            lock (shits)
            {
                int index = shits.Count - 1;
                Shit shit = shits[index];
                shits.RemoveAt(index);
                return shit;
            }
        }
    }
}
