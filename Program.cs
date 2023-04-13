using System.Text.RegularExpressions;

namespace SzyfrBlokowyV5._3
{
    public class Program
    {
        public static void Main()
        {
            //add -> hexa input
            Console.WriteLine("Wprowadz cyfre binarna o dlugosci 8 znakow: ");
            string? input = Console.ReadLine();
            input = input.Trim();

            if (input.Length == 8 && Regex.IsMatch(input, "^[01]+$"))
            {
                var boolArr = ConvertExtension.InputToBoolArray(input);
                var keyItems = KeyGeneratorEngine.KeyGenerator(boolArr.Item1, boolArr.Item2);

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

                var function = FunctionEngine.FunctionS(boolArr.Item2, keyArr);

                //choice window
                //1 encrypt -> FunctionEngine.Encrypt()
                //2 decrypt -> FunctionEngine.Decrypt()
                //display data on console
            }
        }
    }
}
