using System.Text.RegularExpressions;

namespace SzyfrBlokowyV5._3
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Wprowadz cyfrę w formacie szesnastkowym o długości 2 znaków: ");
            string input;
            while (true)
            {
                input = Console.ReadLine();
                input = input.Trim();
                if (input.Length == 2) { break; }
                Console.WriteLine("Nieprawidłowy format. Wprowadź jeszcze raz.");
            }
            Console.WriteLine("Wprowadź klucz w formacie szesnastkowym o długości 2 znaków: ");
            string keyInput;
            while (true)
            {
                keyInput = Console.ReadLine();
                keyInput = keyInput.Trim();
                if (keyInput.Length == 2) { break; }
                Console.WriteLine("Nieprawidłowy format. Wprowadź jeszcze raz.");
            }

            string text = ConvertExtension.HexToBinary(input).PadLeft(8, '0');
            string key = ConvertExtension.HexToBinary(keyInput).PadLeft(8, '0');


            if ((text.Length == 8 && Regex.IsMatch(text, "^[01]+$")) && (key.Length == 8 && Regex.IsMatch(key, "^[01]+$")))
            {
                var boolArrKey = ConvertExtension.StringToDoubleBoolArray(key);
                var keyItems = KeyGeneratorEngine.KeyGenerator(boolArrKey.Item1, boolArrKey.Item2);

                var boolArrText = ConvertExtension.StringToDoubleBoolArray(text);

                var function = FunctionEngine.FunctionS(boolArrText.Item2, keyItems);

                while (true)
                {
                    Console.WriteLine("Co chcesz zrobić?");
                    Console.WriteLine("1. Szyfrowanie");
                    Console.WriteLine("2. Deszyfrowanie");
                    string choice = Console.ReadLine();
                    if (choice == "1") { break; }
                    if (choice == "2") { break; }
                    else { Console.WriteLine("Podaj prawidłową wartość."); }
                }
                //display data on console
            }
            else { Console.WriteLine("Wystąpił nieoczekiwany błąd. Wyjście z programu."); }
        }
    }
}
