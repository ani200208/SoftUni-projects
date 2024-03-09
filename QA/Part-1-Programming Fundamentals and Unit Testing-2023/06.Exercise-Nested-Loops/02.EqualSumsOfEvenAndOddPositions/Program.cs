namespace _02.EqualSumsOfEvenAndOddPositions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first six-digit number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the second six-digit number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                string numberString = i.ToString();
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 0; j < numberString.Length; j++)
                {
                    int digit = int.Parse(numberString[j].ToString());
                    if ((j + 1) % 2 == 0)
                        evenSum += digit;
                    else
                        oddSum += digit;
                }

                if (evenSum == oddSum)
                    Console.Write(i + " ");
            }

            Console.WriteLine(); 
        }
    }
}
