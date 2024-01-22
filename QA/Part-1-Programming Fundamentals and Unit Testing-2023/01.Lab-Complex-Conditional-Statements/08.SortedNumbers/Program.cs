using System;

namespace SortedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int num3 = Convert.ToInt32(Console.ReadLine());
            

            if(num1 <= num2 && num2 <= num3)
            {
                Console.WriteLine("Ascending");
            }
            else if (num3 <= num2 && num2 <= num1) 
            {
                 Console.WriteLine("Descending");
            }
            else
            {
                Console.WriteLine("Not sorted");
            }
        }
    }
}