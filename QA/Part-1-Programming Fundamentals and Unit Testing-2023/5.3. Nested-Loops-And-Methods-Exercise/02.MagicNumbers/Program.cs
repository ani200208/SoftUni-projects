namespace _02.MagicNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 100; i <= 999; i++)
            {
                int digit1 = i / 100;    
                int digit2 = (i / 10) % 10;  
                int digit3 = i % 10;    

                if (digit1 * digit2 * digit3 == N)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
