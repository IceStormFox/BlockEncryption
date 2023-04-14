using System.Text.RegularExpressions;

namespace SzyfrBlokowyV5._3
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Szyfry blokowe - Patryk Kozłowski");
            string choice;
            string input;
            string keyInput;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("\nWybierz typ działania:\n1.Szyfrowanie\n2.Odszyfrowanie");
                    choice = Console.ReadLine();
                    if (choice == "1" || choice == "2") { break; }
                    Console.WriteLine("Nieprawidłowy format. Wprowadź jeszcze raz.");
                }

                while (true)
                {
                    Console.WriteLine("Wprowadz cyfrę w formacie szesnastkowym o długości 2 znaków: ");
                    input = Console.ReadLine().Trim();
                    if (input.Length == 2 && Regex.IsMatch(input, "^[0-9A-F]+$")) { break; }
                    Console.WriteLine("Nieprawidłowy format. Wprowadź jeszcze raz.");
                }

                while (true)
                {
                    Console.WriteLine("Wprowadź klucz w formacie szesnastkowym o długości 2 znaków: ");
                    keyInput = Console.ReadLine().Trim();
                    if (keyInput.Length == 2 && Regex.IsMatch(input, "^[0-9A-F]+$")) { break; }
                    Console.WriteLine("Nieprawidłowy format. Wprowadź jeszcze raz.");
                }

                string text = ConvertExtension.HexToBinary(input).PadLeft(8, '0');
                string key = ConvertExtension.HexToBinary(keyInput).PadLeft(8, '0');

                var boolArrKey = ConvertExtension.StringToDoubleBoolArray(key);
                var keyItems = KeyGeneratorEngine.KeyGenerator(boolArrKey.Item1, boolArrKey.Item2);

                var boolArrText = ConvertExtension.StringToDoubleBoolArray(text);

                string function;
                if (choice == "1") 
                { 
                    function = FunctionEngine.Encrypt(boolArrText.Item1, boolArrText.Item2, keyItems); 
                    Console.WriteLine("Wynik szyfrowania: "); 
                }
                else 
                { 
                    function = FunctionEngine.Decrypt(boolArrText.Item1, boolArrText.Item2, keyItems); 
                    Console.WriteLine("Wynik odszyfrowania: "); 
                }
                Console.WriteLine(ConvertExtension.BinaryToHex(function));

                Console.WriteLine("Kontynuować?\n1.Tak\n2.Nie");
                string end = Console.ReadLine();
                if (end != "1") { break; }
            }
            Console.WriteLine("Następuje wyjście z programu...");
        }
    }
}
