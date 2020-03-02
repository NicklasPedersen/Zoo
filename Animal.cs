using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    // Super class for all animals
    abstract class Animal
    {
        private IShitContainer shitContainer;
        private DateTime lastTimeShit;
        public IShitContainer ShitContainer
        {
            get { return shitContainer; }
            set { shitContainer = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
        }
        private float secondsPerShit;
        public float SecondsPerShit
        {
            get { return secondsPerShit; }
        }
        public Animal(string name, float shitsPerDay)
        {
            this.name = name;
            secondsPerShit = (24*60*60) / shitsPerDay; // Convert shitsPerDay to secondsPerShit
            lastTimeShit = DateTime.Now;
        }
        public abstract Shit Shit();
        public void Exist(float timeWarp)
        {
            while (true)
            {
                double secondsToShit = secondsPerShit * timeWarp - (DateTime.Now - lastTimeShit).TotalSeconds;
                if (secondsToShit <= 0)
                {
                    shitContainer.PlaceShit(Shit());
                    lastTimeShit = DateTime.Now;
                }
                else
                {
                    Thread.Sleep((int)(secondsToShit * 1000));
                }
            }
        }
    }
}
