namespace _10.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            
            List<int> topIntegers = FindTopIntegers(numbers);

            
            Console.WriteLine(string.Join(" ", topIntegers));
        }

        static List<int> FindTopIntegers(int[] numbers)
        {
            List<int> topIntegers = new List<int>();

           
            int maxRight = numbers[numbers.Length - 1];
            topIntegers.Add(maxRight);

            for (int i = numbers.Length - 2; i >= 0; i--)
            {
                if (numbers[i] > maxRight)
                {
                    topIntegers.Add(numbers[i]);
                    maxRight = numbers[i];
                }
            }

           
            topIntegers.Reverse();

            return topIntegers;
        }
    }
}
