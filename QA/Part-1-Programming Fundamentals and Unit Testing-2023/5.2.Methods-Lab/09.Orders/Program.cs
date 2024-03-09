namespace _09.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the product:");
            string product = Console.ReadLine();

            Console.WriteLine("Enter the quantity:");
            int quantity = int.Parse(Console.ReadLine());

            CalculateTotalPrice(product, quantity);
        }

        static void CalculateTotalPrice(string product, int quantity)
        {
            double price = 0;

            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1.00;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2.00;
                    break;
                default:
                    Console.WriteLine("Invalid product entered.");
                    return;
            }

            double totalPrice = price * quantity;
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}

