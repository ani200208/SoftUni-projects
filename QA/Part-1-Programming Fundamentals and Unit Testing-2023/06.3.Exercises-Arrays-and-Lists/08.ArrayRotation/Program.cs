namespace _08.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] numbersStr = Console.ReadLine().Split();
            int[] numbers = new int[numbersStr.Length];

            for (int i = 0; i < numbersStr.Length; i++)
            {
                numbers[i] = int.Parse(numbersStr[i]);
            }

           
            int rotations = int.Parse(Console.ReadLine());

           
            RotateArray(numbers, rotations);

            
            Console.WriteLine(string.Join(" ", numbers));
        }

        static void RotateArray(int[] arr, int rotations)
        {
            int length = arr.Length;

            
            for (int i = 0; i < rotations; i++)
            {
                int firstElement = arr[0];
                for (int j = 0; j < length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[length - 1] = firstElement;
            }
        }
    }
}
