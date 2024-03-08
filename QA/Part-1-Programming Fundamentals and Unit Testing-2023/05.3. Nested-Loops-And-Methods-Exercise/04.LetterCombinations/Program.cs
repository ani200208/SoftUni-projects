namespace _04.LetterCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char excluded = char.Parse(Console.ReadLine());

            GenerateCombinations(start, end, excluded);
        }

        static void GenerateCombinations(char start, char end, char excluded)
        {
            int count = 0;
            for (char i = start; i <= end; i++)
            {
                if (i != excluded)
                {
                    for (char j = start; j <= end; j++)
                    {
                        if (j != excluded)
                        {
                            for (char k = start; k <= end; k++)
                            {
                                if (k != excluded)
                                {
                                    Console.Write($"{i}{j}{k} ");
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(count);
        }
    }
}

