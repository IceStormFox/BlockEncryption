using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrBlokowyV5._3
{
    public class ConvertExtension
    {
        public static (bool[], bool[]) StringToDoubleBoolArray(string input)
        {
            bool[] boolArrLeft = new bool[4];
            bool[] boolArrRight = new bool[4];
            char[] chars = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (chars[i] == '1' && i < 4) { boolArrLeft[i] = true; }
                else if (chars[i] == '0' && i < 4) { boolArrLeft[i] = false; }
                else if (chars[i] == '1' && i >= 4) { boolArrRight[i-4] = true; }
                else { boolArrRight[i-4] = false; }
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
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '1') { arr[i] = true; }
                else { arr[i] = false; }
            }
            return arr;
        }

        public static string HexToBinary(string input)
        {
            return Convert.ToString(Convert.ToInt32(input, 16), 2); ;
        }

        public static string BinaryToHex(string input)
        {
            return Convert.ToString(Convert.ToInt32(input, 2), 16).ToUpper().PadLeft(2, '0'); ;
        }
    }
}
