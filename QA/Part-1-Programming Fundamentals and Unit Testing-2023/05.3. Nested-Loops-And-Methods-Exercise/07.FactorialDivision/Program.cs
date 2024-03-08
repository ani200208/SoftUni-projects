namespace _07.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            long factorial1 = CalculateFactorial(number1);
            long factorial2 = CalculateFactorial(number2);

            long result = factorial1 / factorial2;

            Console.WriteLine(result);
        }

        static long CalculateFactorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
