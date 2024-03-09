namespace _03.SumOfPrimeAndNon_PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                    break;

                int number;
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer or 'stop'.");
                    continue;
                }

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                if (IsPrime(number))
                    primeSum += number;
                else
                    nonPrimeSum += number;
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }

        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number <= 3)
                return true;
            if (number % 2 == 0 || number % 3 == 0)
                return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }
    }
}
