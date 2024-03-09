namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of jury members: ");
            int n = int.Parse(Console.ReadLine());

            double totalSum = 0;
            int presentationCount = 0;

            while (true)
            {
                string presentation = Console.ReadLine();

                if (presentation == "Finish")
                    break;

                double presentationSum = 0;

                for (int i = 0; i < n; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    presentationSum += grade;
                }

                double averageGrade = presentationSum / n;
                totalSum += averageGrade;
                presentationCount++;

                Console.WriteLine($"{presentation} - {averageGrade:f2}.");
            }

            double overallAverage = totalSum / presentationCount;
            Console.WriteLine($"Student's final assessment is {overallAverage:f2}.");
        }
    }
}

