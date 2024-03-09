namespace _09.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            ValidatePassword(password);
        }

        static void ValidatePassword(string password)
        {
            bool isValid = true;

            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (!password.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (password.Count(char.IsDigit) < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
