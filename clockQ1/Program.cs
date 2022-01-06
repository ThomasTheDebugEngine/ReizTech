using System;

namespace clockQ1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("please enter the time in analog format, ex: 09:45, include a 0 for single digits, ex: 08:05");
            string UserTime = Console.ReadLine();

            Clock clock = new(UserTime);
            clock.SolveAngle();
        }    
    }
}
