namespace SummerClothing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            string clothing = "";
            string shoes = "";

            if (timeOfDay == "Morning")
            {
                if (temperature >= 10 && temperature <= 18)
                {
                    clothing = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (temperature > 18 && temperature <= 24)
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
                else
                {
                    clothing = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (timeOfDay == "Afternoon")
            {
                if (temperature >= 10 && temperature <= 18)
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
                else if (temperature > 18 && temperature <= 24)
                {
                    clothing = "T-Shirt";
                    shoes = "Sandals";
                }
                else
                {
                    clothing = "Swim Suit";
                    shoes = "Barefoot";
                }
            }
            else // Evening
            {
                if (temperature >= 10 && temperature <= 18)
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
                else if (temperature > 18 && temperature <= 24)
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
                else
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
            }

            Console.WriteLine($"It's {temperature} degrees, get your {clothing} and {shoes}.");
        }
    }
    
}
