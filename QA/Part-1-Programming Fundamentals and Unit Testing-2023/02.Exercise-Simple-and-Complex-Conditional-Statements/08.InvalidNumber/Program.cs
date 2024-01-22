using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main()
        {
            

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if ((number >= 100 && number <= 200) || number == 0)
                {
                    Console.WriteLine(" NOT Valid");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}

