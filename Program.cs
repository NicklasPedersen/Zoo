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
                Elephant elephant = elephants[i];
                Thread thread = new Thread(() => elephant.Exist(timeWarp));
                threads.Add(thread);
            }
            AnimalContainer foxContainer = new AnimalContainer("Fox");
            List<Fox> foxes = new List<Fox>();
            for (int i = 0; i < 6; i++)
            {
                foxes.Add(new Fox());
                foxContainer.PlaceAnimal(foxes[i]);
                Fox fox = foxes[i];
                Thread thread = new Thread(() => fox.Exist(timeWarp));
                threads.Add(thread);
            }
            List<AnimalContainer> animalContainers = new List<AnimalContainer>
            {
                elephantContainer,
                foxContainer,
            };
            ZooPark zoo = new ZooPark(animalContainers);

            for (int i = 0; i < 300; i++)
            {
                Guest guest = new Guest();
                guests.Add(guest);
                Thread thread = new Thread(() => guest.GoToPark(zoo));
                threads.Add(thread);
            }
            EventWaitHandle[] handles = new EventWaitHandle[animalContainers.Count];
            for (int i = 0; i < animalContainers.Count; i++)
            {
                handles[i] = animalContainers[i].hasShit;
            }
            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < 2; i++)
            {
                Worker worker = new Worker(zoo);
                Thread thread = new Thread(() => worker.Work(timeWarp));
                threads.Add(thread);
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
                    // Find max length of all containers
                    maxLenth = maxLenth < container.Name.Length ? container.Name.Length : maxLenth;
                }
                Console.WriteLine();
                for (int i = 0; i < animalContainers.Count; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(animalContainers[i].Name);
                    Console.SetCursorPosition(maxLenth + 1, i);
                    float poopAmount = animalContainers[i].Shits.Count / 500.0f;
                    poopAmount = poopAmount > 1 ? 1 : poopAmount;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    // Calculate amount of space left
                    float ratio = (Console.BufferWidth - maxLenth - 2) * poopAmount;
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
