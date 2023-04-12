using System.Text.RegularExpressions;

namespace SzyfrBlokowyV5._3
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Wprowadz cyfre binarna o dlugosci 8 znakow: ");
            string ?input = Console.ReadLine();
            input = input.Trim();

            if (input.Length == 8 && Regex.IsMatch(input, "^[01]+$")) 
            {
                KeyGeneratorEngine.InputToBoolArray(input);
            }
        }
    }
}
