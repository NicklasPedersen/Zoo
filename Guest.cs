using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    class Guest
    {
        float contentment;
        public float Contentment
        {
            get { return contentment; }
        }
        public Guest()
        {
            contentment = 1; // 100% Content
        }
        public void GoToPark(ZooPark park)
        {
            while (true)
            {
                foreach (AnimalContainer container in park.Animals)
                {
                    contentment /= container.Shits.Count;
                }
                Thread.Sleep(1000);
            }
        }
    }
}
