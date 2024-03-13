namespace _03.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> positiveNumbers = numbers.Where(x => x >= 0).ToList();

            if (positiveNumbers.Count > 0)
            {
                positiveNumbers.Reverse();
                Console.WriteLine(string.Join(" ", positiveNumbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
