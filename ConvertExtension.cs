using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrBlokowyV5._3
{
    public class ConvertExtension
    {
        public static (bool[], bool[]) InputToBoolArray(string input)
        {
            bool[] boolArrLeft = new bool[4];
            bool[] boolArrRight = new bool[4];
            char[] chars = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (chars[i] == '1' && i < 4) { boolArrLeft[i] = true; }
                else if (chars[i] == '0' && i < 4) { boolArrLeft[i] = false; }
                else if (chars[i] == '1' && i >= 4) { boolArrRight[i] = true; }
                else { boolArrRight[i] = false; }
            }
            return (boolArrLeft, boolArrRight);
        }

        public static string ArrayToString(bool[] arr)
        {
            StringBuilder result = new();
            foreach (var item in arr)
            {
                result.Append(item ? "1" : "0");
            }
            return result.ToString();
        }

        public static bool[] StringToArray(string text)
        {
            bool[] arr = new bool[text.Length];
            char[] chars = text.ToCharArray();

            foreach (char c in chars)
            {
                if (c == '1') { arr.Append(true); }
                else { arr.Append(false); }
            }
            return arr;
        }

        public static string HexToBinary(string input)
        {
            //Conversion hex to bin
            return input;
        }

        public static string BinaryToHex(string input)
        {
            //Conversion bin to hex
            return input;
        }
    }
}
