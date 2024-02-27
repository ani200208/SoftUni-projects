namespace _05.SumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialNumber = int.Parse(Console.ReadLine());

            
            int sum = 0;
            int currentNumber;

            
            while (sum < initialNumber)
            {
                currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
            }

            
            Console.WriteLine(sum);
        }
    }
    
}
