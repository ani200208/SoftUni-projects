namespace _10.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            
            int grade = 1;
            double sumGrades = 0;
            int expelledGrade = 0;
            bool expelled = false;

            
            while (grade <= 12)
            {
                
                double annualGrade = double.Parse(Console.ReadLine());

                
                if (annualGrade < 4)
                {
                    expelled = true;
                    expelledGrade = grade;
                    break;
                }

                
                sumGrades += annualGrade;

                
                grade++;
            }

           
            if (expelled)
            {
                Console.WriteLine($"{name} has been excluded at {expelledGrade} grade");
            }
            else
            {
                double averageGrade = sumGrades / 12;
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
