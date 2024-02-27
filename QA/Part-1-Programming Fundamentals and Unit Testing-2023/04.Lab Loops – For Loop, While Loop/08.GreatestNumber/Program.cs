namespace _08.GreatestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.MinValue; 

            
            while (true)
            {
                string input = Console.ReadLine();

                
                if (input == "Stop")
                    break;

                
                int number;
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Invalid input. Please enter an integer or 'Stop'.");
                    continue;
                }

                
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            
            Console.WriteLine(maxNumber);
        }
    }
    
}
