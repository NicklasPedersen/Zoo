using System;
using System.Collections.Generic;
using System.Threading;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Guest> guests = new List<Guest>();
            List<Thread> threads = new List<Thread>();
            AnimalContainer elephantContainer = new AnimalContainer("Elephants");
            List<Elephant> elephants = new List<Elephant>();
            float timeWarp = 0.0001f;
            for (int i = 0; i < 6; i++)
            {
                elephants.Add(new Elephant());
                elephantContainer.PlaceAnimal(elephants[i]);
                Elephant e = elephants[i];
                Thread t = new Thread(() => e.Exist(timeWarp));
                threads.Add(t);
            }
            AnimalContainer foxContainer = new AnimalContainer("Fox");
            List<Fox> foxes = new List<Fox>();
            for (int i = 0; i < 6; i++)
            {
                foxes.Add(new Fox());
                foxContainer.PlaceAnimal(foxes[i]);
                Fox f = foxes[i];
                Thread t = new Thread(() => f.Exist(timeWarp));
                threads.Add(t);
            }
            List<AnimalContainer> animalContainers = new List<AnimalContainer>
            {
                elephantContainer,
                foxContainer,
            };
            Park p = new Park(animalContainers);

            for (int i = 0; i < 300; i++)
            {
                Guest g = new Guest();
                guests.Add(g);
                Thread t = new Thread(() => g.GoToPark(p));
                threads.Add(t);
            }
            EventWaitHandle[] handles = new EventWaitHandle[animalContainers.Count];
            for (int i = 0; i < animalContainers.Count; i++)
            {
                handles[i] = animalContainers[i].hasShit;
            }
            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < 2; i++)
            {
                Worker worker = new Worker(p);
                Thread t = new Thread(() => worker.Work(timeWarp));
                threads.Add(t);
            }
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Start();
            }
            ConsoleColor originalColor = Console.BackgroundColor;
            while (true)
            {
                int maxLenth = 0;
                foreach (AnimalContainer container in animalContainers)
                {
                    maxLenth = maxLenth < container.Name.Length ? container.Name.Length : maxLenth;
                }
                for (int i = 0; i < animalContainers.Count; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(animalContainers[i].Name);
                    Console.SetCursorPosition(maxLenth + 1, i);
                    float poopAmount = animalContainers[i].Shits.Count / 500.0f;
                    poopAmount = poopAmount > 1 ? 1 : poopAmount;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    float ratio = (Console.BufferWidth - maxLenth - 1) * poopAmount;
                    for (int j = 0; j < (int)(ratio); j++)
                    {
                        Console.Write(' ');
                    }
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
                int index = WaitHandle.WaitAny(handles);
                handles[index].Reset();
                Console.WriteLine("Container " + animalContainers[index].Name + " has shit");
            }
        }
    }
}
