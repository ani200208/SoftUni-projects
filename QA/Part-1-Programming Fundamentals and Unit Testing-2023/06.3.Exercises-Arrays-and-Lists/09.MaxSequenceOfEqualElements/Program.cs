namespace _09.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

           
            int[] longestSequence = FindLongestSequence(numbers);

           
            Console.WriteLine(string.Join(" ", longestSequence));
        }

        static int[] FindLongestSequence(int[] numbers)
        {
            int maxLength = 0;
            int maxStartIndex = 0;

            int currentLength = 1;
            int currentStartIndex = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentLength++;

                   
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxStartIndex = currentStartIndex;
                    }
                }
                else
                {
                    currentLength = 1;
                    currentStartIndex = i;
                }
            }

            
            int[] longestSequence = new int[maxLength];
            Array.Copy(numbers, maxStartIndex, longestSequence, 0, maxLength);

            return longestSequence;
        }
    }
}
