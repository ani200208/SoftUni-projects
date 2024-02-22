namespace _08.OnTimeForExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());

            int examTimeInMinutes = examHour * 60 + examMinute;
            int arrivalTimeInMinutes = arrivalHour * 60 + arrivalMinute;

            int difference = arrivalTimeInMinutes - examTimeInMinutes;

            if (difference > 0)
            {
                Console.WriteLine("Late");
                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else
                {
                    int hours = difference / 60;
                    int minutes = difference % 60;
                    Console.WriteLine($"{hours}:{minutes:D2} hours after the start");
                }
            }
            else if (difference >= -30)
            {
                Console.WriteLine("On time");
                if (difference != 0)
                {
                    Console.WriteLine($"{Math.Abs(difference)} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Early");
                if (Math.Abs(difference) < 60)
                {
                    Console.WriteLine($"{Math.Abs(difference)} minutes before the start");
                }
                else
                {
                    int hours = Math.Abs(difference) / 60;
                    int minutes = Math.Abs(difference) % 60;
                    Console.WriteLine($"{hours}:{minutes:D2} hours before the start");
                }
            }
        }
    }
}
