namespace _01.NestedLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 2; i <= N; i += 2)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (j % 2 != 0)
                    {
                        int product = i * j;
                        Console.Write($"{i}{j}{product} ");
                    }
                }
            }
        }
    }
}
