using System.Text.RegularExpressions;

namespace SzyfrBlokowyV5._3
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Szyfry blokowe - Patryk Kozłowski");
            string choice, input, keyInput;

            while (true)
            {
                do
                {
                    Console.WriteLine("\nWybierz typ działania:\n1.Szyfrowanie\n2.Odszyfrowanie");
                    choice = Console.ReadLine();
                } 
                while (choice != "1" && choice != "2");

                input = GetInput("Wprowadz cyfrę w formacie szesnastkowym o długości 2 znaków: ");
                keyInput = GetInput("Wprowadź klucz w formacie szesnastkowym o długości 2 znaków: ");

                string text = ConvertExtension.HexToBinary(input).PadLeft(8, '0');
                string key = ConvertExtension.HexToBinary(keyInput).PadLeft(8, '0');
                var keyItems = KeyGeneratorEngine.KeyGenerator(
                    ConvertExtension.StringToDoubleBoolArray(key).Item1, 
                    ConvertExtension.StringToDoubleBoolArray(key).Item2);
                var function = (choice == "1") ? FunctionEngine.RoundEngine(
                    ConvertExtension.StringToDoubleBoolArray(text).Item1, 
                    ConvertExtension.StringToDoubleBoolArray(text).Item2, 
                    keyItems, Convert.ToInt32(choice)) : FunctionEngine.RoundEngine(
                        ConvertExtension.StringToDoubleBoolArray(text).Item1, 
                        ConvertExtension.StringToDoubleBoolArray(text).Item2, 
                        keyItems, Convert.ToInt32(choice));
                Console.WriteLine((choice == "1") ? "\nWynik szyfrowania: " : "\nWynik odszyfrowania: ");
                Console.WriteLine(ConvertExtension.BinaryToHex(function));

                Console.WriteLine("\nKontynuować?\n1.Tak\n2.Nie");
                if (Console.ReadLine().Equals("2")) { break; }
            }
            Console.WriteLine("Następuje wyjście z programu...");
        }

        public static string GetInput(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine().Trim();
                if (input.Length == 2 && Regex.IsMatch(input, "^[0-9A-F]+$")) { return input; }
                Console.WriteLine("Nieprawidłowy format. Wprowadź jeszcze raz.");
            }
        }

    }
}
