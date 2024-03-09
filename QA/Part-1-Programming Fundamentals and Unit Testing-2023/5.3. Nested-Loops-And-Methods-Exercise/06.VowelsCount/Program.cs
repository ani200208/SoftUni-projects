namespace _06.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int vowelsCount = CountVowels(text);

            Console.WriteLine(vowelsCount);
        }

        static int CountVowels(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (IsVowel(c))
                {
                    count++;
                }
            }
            return count;
        }

        static bool IsVowel(char c)
        {
            c = char.ToLower(c);
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
    }
}
