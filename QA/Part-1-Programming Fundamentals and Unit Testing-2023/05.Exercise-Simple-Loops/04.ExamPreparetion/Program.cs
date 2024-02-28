namespace _04.ExamPreparetion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxPoorGrades = int.Parse(Console.ReadLine());

            // Initialize variables
            int poorGradesCount = 0;
            int solvedProblemsCount = 0;
            double totalGrade = 0;
            string lastProblem = "";
            bool isFailed = true;

            // Main loop
            while (poorGradesCount < maxPoorGrades)
            {
                string problemName = Console.ReadLine();
                if (problemName == "Enough")
                {
                    isFailed = false;
                    break;
                }

                int grade = int.Parse(Console.ReadLine());

                // Update total grade and problem count
                totalGrade += grade;
                solvedProblemsCount++;
                lastProblem = problemName;

                // Check if the grade is poor
                if (grade <= 4)
                    poorGradesCount++;
            }

            // Print output
            if (isFailed)
            {
                Console.WriteLine($"You need a break, {poorGradesCount} poor grades.");
            }
            else
            {
                double averageGrade = totalGrade / solvedProblemsCount;
                Console.WriteLine($"Average score: {averageGrade:F2}");
                Console.WriteLine($"Number of problems: {solvedProblemsCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
