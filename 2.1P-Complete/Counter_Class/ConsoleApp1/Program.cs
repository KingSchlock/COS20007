using System;

namespace CounterClass
{
    internal class CounterProgram
    { 
        private static void PrintCounters(Counter[] myCounters)
        {
            foreach (Counter counter in myCounters)
            {
                Console.WriteLine("{0} is {1}", counter.NameCounter, counter.Tick);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];
            
            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];

            for(int i = 0; i < 10; i++)
            {
                myCounters[0].IncrementCounter();
            }

            for (int i = 0; i < 15; i++)
            {
                myCounters[1].IncrementCounter();
            }

            CounterProgram.PrintCounters(myCounters);
            myCounters[2].ResetCounter();

            CounterProgram.PrintCounters(myCounters);   
        }
    }
}