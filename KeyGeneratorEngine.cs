using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrBlokowyV5._3
{
    public class KeyGeneratorEngine
    {
        public static void InputToBoolArray(string input)
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
            KeyGenerator(boolArrLeft, boolArrRight);
        }
        public static bool[] Merge(bool[] boolArrLeft, bool[] boolArrRight)
        {
            foreach (bool item in boolArrRight) { boolArrLeft.Append(item); }
            return boolArrLeft;
        }
        public static (bool[], bool[]) Split(bool[] boolArr)
        {
            bool[] boolArrLeft = new bool[4];
            bool[] boolArrRight = new bool[4];
            int i = 0;
            while (i < boolArr.Length)
            {
                if (i < 4) { boolArrLeft[i] = boolArr[i]; }
                else { boolArrRight[i - 4] = boolArr[i]; }
                i++;
            }
            return (boolArrLeft, boolArrRight);
        }
        public static void KeyGenerator(bool[] boolArrLeft, bool[] boolArrRight)
        {
            uint round = 0;
            bool[] boolArr = new bool[8];
            while (round < 4)
            {
                if (round % 2 == 0) { boolArr = Merge(boolArrLeft, boolArrRight); }
                else { Split(boolArr); }
                round++;
            }
        }
    }
}
