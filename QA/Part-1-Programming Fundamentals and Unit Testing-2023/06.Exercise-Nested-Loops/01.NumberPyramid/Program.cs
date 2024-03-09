namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a whole number: ");
            int n = int.Parse(Console.ReadLine());

            int num = 1;
            bool exitOuterLoop = false;

            for (int i = 1; i <= n; i++)
            {
                bool exitInnerLoop = false;
                for (int j = 1; j <= i; j++)
                {
                    if (num > n)
                    {
                        exitInnerLoop = true;
                        break;
                    }

                    Console.Write(num + " ");
                    num++;
                }

                if (exitInnerLoop)
                {
                    exitOuterLoop = true;
                    break;
                }

                Console.WriteLine();
            }

            if (!exitOuterLoop)
            {
                Console.WriteLine();
                for (int i = n + 1; ; i += 4)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        if (num > n)
                        {
                            exitOuterLoop = true;
                            break;
                        }

                        Console.Write(num + " ");
                        num++;
                    }

                    Console.WriteLine();

                    if (exitOuterLoop)
                        break;
                }
            }
        }
}    }

