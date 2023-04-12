using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrBlokowyV5._3
{
    public class ConvertExtension
    {
        public static string ArrayToString(bool[] arr)
        {
            StringBuilder result = new();
            foreach(var item in arr)
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
    }
}
