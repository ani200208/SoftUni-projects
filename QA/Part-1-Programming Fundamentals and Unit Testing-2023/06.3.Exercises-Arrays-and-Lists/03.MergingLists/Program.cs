namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first sequence of integers separated by spaces:");
            List<int> firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Console.WriteLine("Enter the second sequence of integers separated by spaces:");
            List<int> secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> mergedList = MergeLists(firstList, secondList);

            Console.WriteLine("Merged list:");
            Console.WriteLine(string.Join(" ", mergedList));
        }

        static List<int> MergeLists(List<int> firstList, List<int> secondList)
        {
            List<int> mergedList = new List<int>();

            int minLength = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < minLength; i++)
            {
                mergedList.Add(firstList[i]);
                mergedList.Add(secondList[i]);
            }

         
            if (firstList.Count > secondList.Count)
                mergedList.AddRange(firstList.Skip(minLength));
            else if (secondList.Count > firstList.Count)
                mergedList.AddRange(secondList.Skip(minLength));

            return mergedList;
        }
    }
}

