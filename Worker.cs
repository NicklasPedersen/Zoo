using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    class Worker
    {
        ZooPark workPlace;
        public Worker(ZooPark workPlace)
        {
            this.workPlace = workPlace;
        }
        public void Work(float timeWarp)
        {
            EventWaitHandle[] handles = new EventWaitHandle[workPlace.Animals.Count];
            for (int i = 0; i < handles.Length; i++)
            {
                handles[i] = workPlace.Animals[i].isWork;
            }
            while (true)
            {
                int workIndex = WaitHandle.WaitAny(handles);
                Shit shit = workPlace.Animals[workIndex].RemoveShit();
                Thread.Sleep((int)(shit.SecondsToClean * timeWarp));
            }
        }
    }
}
