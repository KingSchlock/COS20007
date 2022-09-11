namespace ClockClass
{
    class ClockProgram
    {
        static void Main()
        {
            Clock clock = new();

            for (int i = 0; i < 86400; i++)
            {
                clock.IncrementClock();
                Console.WriteLine(clock.ReadClock());
            }
        }
    }
}