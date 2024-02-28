namespace _06.Steps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000; 
            int totalSteps = 0; 

            string input;
            while ((input = Console.ReadLine()) != "Going home")
            {
                int steps = int.Parse(input);
                totalSteps += steps;

                if (totalSteps >= goal)
                {
                    int difference = totalSteps - goal;
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{difference} steps over the goal!");
                    return;
                }
            }

            int stepsGoingHome = int.Parse(Console.ReadLine());
            totalSteps += stepsGoingHome;

            if (totalSteps >= goal)
            {
                int difference = totalSteps - goal;
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{difference} steps over the goal!");
            }
            else
            {
                int difference = goal - totalSteps;
                Console.WriteLine($"{difference} more steps to reach goal.");
            }
        }
    }
}
