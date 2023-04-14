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
        public static bool[] BitShiftLeft(bool[] boolArr, int size)
        {
            bool[] shiftedArr = new bool[boolArr.Length];
            Array.Copy(boolArr, 1, shiftedArr, 0, boolArr.Length - 1);
            shiftedArr[shiftedArr.Length - 1] = false;
            return shiftedArr.TakeLast(size).ToArray();
        }


        public static bool[] Merge(bool[] boolArrLeft, bool[] boolArrRight)
        {
            bool[] boolArr = new bool[boolArrLeft.Length + boolArrRight.Length];
            boolArrLeft.CopyTo(boolArr, 0);
            boolArrRight.CopyTo(boolArr, boolArrLeft.Length);
            return boolArr;
        }

        public static (bool[], bool[]) Split(bool[] boolArr)
        {
            bool[] boolArrLeft = new bool[boolArr.Length / 2];
            bool[] boolArrRight = new bool[boolArr.Length / 2];
            for (int i = 0; i < boolArr.Length; i++)
            {
                if (i < boolArr.Length / 2) { boolArrLeft[i] = boolArr[i]; }
                else { boolArrRight[i - boolArr.Length / 2] = boolArr[i]; }
            }
            return (boolArrLeft, boolArrRight);
        }


        public static bool[][] KeyGenerator(bool[] boolArrLeft, bool[] boolArrRight)
        {
            bool[][] keys = new bool[8][];
            bool[] boolArr = new bool[8];

            for (int i = 0; i < keys.Length; i++)
            {
                if (i % 2 == 0)
                {
                    boolArrLeft = BitShiftLeft(boolArrLeft, 4);
                    boolArrRight = BitShiftLeft(boolArrRight, 4);
                    keys[i] = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] };
                    boolArr = Merge(boolArrLeft, boolArrRight);
                }
                else
                {
                    boolArr = BitShiftLeft(boolArr, 8);
                    keys[i] = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] };
                    var splitArr = Split(boolArr);
                    boolArrLeft = splitArr.Item1;
                    boolArrRight = splitArr.Item2;
                }
            }
            return keys;
        }
    }
}
