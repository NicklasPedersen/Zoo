using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Shit
    {
        private float secondsToClean;
        public float SecondsToClean
        {
            get { return secondsToClean; }
        }
        public Shit(float minutesToClean)
        {
            this.secondsToClean = minutesToClean * 60f;
        }
    }
}
