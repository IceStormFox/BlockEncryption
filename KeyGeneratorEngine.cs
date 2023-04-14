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
            string tempString = ConvertExtension.ArrayToString(boolArr);
            int binNum = Convert.ToInt32(tempString, 2);
            int shiftedNum = binNum << 1;
            tempString = Convert.ToString(shiftedNum, toBase: 2).PadLeft(8, '0');
            tempString = tempString.Substring(tempString.Length - size, size);
            return ConvertExtension.StringToArray(tempString);
        }

        public static bool[] Merge(bool[] boolArrLeft, bool[] boolArrRight)
        {
            bool[] boolArr = new bool[8];
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

            bool[][] k = new bool[8][];
            for (int i = 0; i < k.Length; i++)
            {
                k[i] = new bool[4];
            }

            while (round < 8)
            {
                switch (round)
                {
                    case 0:
                        boolArrLeft = BitShiftLeft(boolArrLeft, 4); 
                        boolArrRight = BitShiftLeft(boolArrRight, 4); 
                        k[round] = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] };
                        boolArr = Merge(boolArrLeft, boolArrRight); 
                        break; 
                    case 1:
                        boolArr = BitShiftLeft(boolArr, 8);
                        k[round] = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] }; 
                        var splitArr = Split(boolArr); 
                        boolArrLeft = splitArr.Item1; 
                        boolArrRight = splitArr.Item2;
                        break; 
                    case 2:
                        boolArrLeft = BitShiftLeft(boolArrLeft, 4);
                        boolArrRight = BitShiftLeft(boolArrRight, 4);
                        k[round] = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] }; 
                        boolArr = Merge(boolArrLeft, boolArrRight); 
                        break;
                    case 3:
                        boolArr = BitShiftLeft(boolArr, 8);
                        k[round] = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] }; 
                        splitArr = Split(boolArr); 
                        boolArrLeft = splitArr.Item1; 
                        boolArrRight = splitArr.Item2; 
                        break;
                    case 4:
                        boolArrLeft = BitShiftLeft(boolArrLeft, 4);
                        boolArrRight = BitShiftLeft(boolArrRight, 4);
                        k[round] = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] }; 
                        boolArr = Merge(boolArrLeft, boolArrRight); 
                        break;
                    case 5:
                        boolArr = BitShiftLeft(boolArr, 8);
                        k[round] = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] }; 
                        splitArr = Split(boolArr); 
                        boolArrLeft = splitArr.Item1; 
                        boolArrRight = splitArr.Item2; 
                        break;
                    case 6:
                        boolArrLeft = BitShiftLeft(boolArrLeft, 4);
                        boolArrRight = BitShiftLeft(boolArrRight, 4);
                        k[round] = new bool[] { boolArrLeft[0], boolArrLeft[2], boolArrRight[0], boolArrRight[2] };
                        boolArr = Merge(boolArrLeft, boolArrRight); 
                        break;
                    case 7:
                        boolArr = BitShiftLeft(boolArr, 8);
                        k[round] = new bool[] { boolArr[0], boolArr[2], boolArr[4], boolArr[6] }; 
                        splitArr = Split(boolArr); 
                        boolArrLeft = splitArr.Item1; 
                        boolArrRight = splitArr.Item2; 
                        break;
                }
                round++;
            }
            return k;
        }
    }
}
