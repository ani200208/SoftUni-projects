namespace _06.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the base number:");
            int baseNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the power:");
            int power = Convert.ToInt32(Console.ReadLine());

            int result = CalculatePower(baseNumber, power);
            Console.WriteLine("Result: " + result);
        }

        static int CalculatePower(int baseNumber, int power)
        {
            int result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= baseNumber;
            }

            return result;
        }
    }
}

