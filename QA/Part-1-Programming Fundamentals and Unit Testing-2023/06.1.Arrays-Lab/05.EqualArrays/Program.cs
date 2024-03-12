namespace _05.EqualArrays
{
    internal class Program
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Enter elements of the first array separated by space:");
                string input1 = Console.ReadLine();
                Console.WriteLine("Enter elements of the second array separated by space:");
                string input2 = Console.ReadLine();

                string[] array1 = input1.Split(' ');
                string[] array2 = input2.Split(' ');

                if (array1.Length != array2.Length)
                {
                    Console.WriteLine("Arrays are not identical.");
                    return;
                }

                bool identical = true;

                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        identical = false;
                        break;
                    }
                }

                if (identical)
                {
                    Console.WriteLine("Arrays are identical.");
                }
                else
                {
                    Console.WriteLine("Arrays are not identical.");
                }
            }
        }
    }
}
