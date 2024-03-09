namespace _03.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            int max1 = int.Parse(Console.ReadLine());
            int max2 = int.Parse(Console.ReadLine());
            int max3 = int.Parse(Console.ReadLine());

            
            GeneratePincodes(max1, max2, max3);
        }

        static void GeneratePincodes(int max1, int max2, int max3)
        {
          
            for (int i = 1; i <= max1; i++)
            {
                for (int j = 1; j <= max2; j++)
                {
                    for (int k = 1; k <= max3; k++)
                    {
                        
                        if (i % 2 == 0 && k % 2 == 0 && IsPrime(j))
                        {
                            Console.WriteLine($"{i}{j}{k}");
                        }
                    }
                }
            }
        }

        
        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
