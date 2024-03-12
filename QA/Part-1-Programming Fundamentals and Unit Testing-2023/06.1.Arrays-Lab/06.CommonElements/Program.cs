namespace _06.CommonElements
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
                    Console.WriteLine("Arrays must have the same length.");
                    return;
                }

                HashSet<string> set = new HashSet<string>();

                foreach (string element in array1)
                {
                    set.Add(element);
                }

                Console.Write("Common elements: ");
                foreach (string element in array2)
                {
                    if (set.Contains(element))
                    {
                        Console.Write(element + " ");
                    }
                }
            }
        }
    }
}
