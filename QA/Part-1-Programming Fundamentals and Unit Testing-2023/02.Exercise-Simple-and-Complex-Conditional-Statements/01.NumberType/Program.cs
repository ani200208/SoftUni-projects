using System;

namespace NumberType
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int number = Convert.ToInt32(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine("negative");
            }
            else if (number > 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("zero");
            }
           
        }
    }
}