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
        public static bool[] Merge(bool[] boolArrLeft, bool[] boolArrRight)
        {
            bool[] boolArr = new bool[boolArrLeft.Length + boolArrRight.Length];
            boolArrLeft.CopyTo(boolArr, 0);
            boolArrRight.CopyTo(boolArr, boolArrLeft.Length);
            return boolArr;
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

        public static bool[][] KeyGenerator(bool[] boolArrLeft, bool[] boolArrRight)
        {
            uint round = 0;
            bool[] boolArr = new bool[8];
            bool[] k1 = new bool[4];
            bool[] k2 = new bool[4];
            bool[] k3 = new bool[4];
            bool[] k4 = new bool[4];
            bool[] k5 = new bool[4];
            bool[] k6 = new bool[4];
            bool[] k7 = new bool[4];
            bool[] k8 = new bool[4];

            while (round < 8)
            {
                switch (round)
                {
                    case 0: k1 = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] }; boolArr = Merge(boolArrLeft, boolArrRight); break; 
                    case 1: k2 = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] }; var splitArr = Split(boolArr); boolArrLeft = splitArr.Item1; boolArrRight = splitArr.Item2;break; 
                    case 2: k3 = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] }; boolArr = Merge(boolArrLeft, boolArrRight); break;
                    case 3: k4 = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] }; splitArr = Split(boolArr); boolArrLeft = splitArr.Item1; boolArrRight = splitArr.Item2; break;
                    case 4: k5 = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] }; boolArr = Merge(boolArrLeft, boolArrRight); break;
                    case 5: k6 = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] }; splitArr = Split(boolArr); boolArrLeft = splitArr.Item1; boolArrRight = splitArr.Item2; break;
                    case 6: k7 = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] }; boolArr = Merge(boolArrLeft, boolArrRight); break;
                    case 7: k8 = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] }; splitArr = Split(boolArr); boolArrLeft = splitArr.Item1; boolArrRight = splitArr.Item2; break;
                }
                round++;
            }
            bool[][] jaggeredArr = new bool[][] { k1, k2, k3, k4, k5, k6, k7, k8 };
            return jaggeredArr;
        }
    }
}
