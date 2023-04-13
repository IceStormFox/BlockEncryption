using System.Text.RegularExpressions;

namespace SzyfrBlokowyV5._3
{
    public class Program
    {
        public static void Main()
        {
            //add -> hexa input
            Console.WriteLine("Wprowadz cyfrę w formacie szesnastkowym o długości 2 znaków: ");
            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();
                input = input.Trim();
                if (input.Length == 2) { break; }
                Console.WriteLine("Nieprawidłowy format. Wprowadź jeszcze raz.");
            }
            Console.WriteLine("Wprowadź klucz w formacie szesnastkowym o długości 2 znaków: ");
            string keyInput = string.Empty;
            while (true)
            {
                keyInput = Console.ReadLine();
                keyInput = keyInput.Trim();
                if (keyInput.Length == 2) { break; }
                Console.WriteLine("Nieprawidłowy format. Wprowadź jeszcze raz.");
            }

            string text = ConvertExtension.HexToBinary(input);
            string key = ConvertExtension.HexToBinary(keyInput);


            if (input.Length == 8 && Regex.IsMatch(input, "^[01]+$"))
            {
                var boolArrKey = ConvertExtension.StringToDoubleBoolArray(key);
                var keyItems = KeyGeneratorEngine.KeyGenerator(boolArrKey.Item1, boolArrKey.Item2);

                var boolArrText = ConvertExtension.StringToDoubleBoolArray(text);

                bool[,] keyArr = new bool[4, 4];

                for (int i = 0;i < 4; i++) 
                {
                    for (int j = 0; j < 4; j++) 
                    {
                        if (i == 0) { keyArr[i, j] = keyItems.Item1[j]; }
                        if (i == 1) { keyArr[i, j] = keyItems.Item2[j]; }
                        if (i == 2) { keyArr[i, j] = keyItems.Item3[j]; }
                        if (i == 3) { keyArr[i, j] = keyItems.Item4[j]; }
                    }
                }

                var function = FunctionEngine.FunctionS(boolArrText.Item2, keyArr);

                //choice window
                //1 encrypt -> FunctionEngine.Encrypt()
                //2 decrypt -> FunctionEngine.Decrypt()
                //display data on console
            }
            else { Console.WriteLine("Wystąpił nieoczekiwany błąd"); }
        }
    }
}
