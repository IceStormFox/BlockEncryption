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

        public static (bool[], bool[]) SwitchArrays(bool[] arrLeft, bool[] arrRight)
        {
            bool[] temp = new bool[4];
            temp = arrLeft;
            arrLeft = arrRight;
            arrRight = temp;
            return (arrLeft, arrRight);
        }

        public static (bool[], bool[], bool[], bool[]) KeyGenerator(bool[] boolArrLeft, bool[] boolArrRight)
        {
            uint round = 0;
            bool[] boolArr = new bool[8];
            bool[] k1 = new bool[4];
            bool[] k2 = new bool[4];
            bool[] k3 = new bool[4];
            bool[] k4 = new bool[4];
            while (round < 4)
            {
                if (round % 2 == 0)
                {
                    if (round == 0)
                    {
                        k1[0] = boolArrLeft[0];
                        k1[1] = boolArrLeft[2];
                        k1[2] = boolArrRight[0];
                        k1[3] = boolArrRight[2];
                    }
                    else
                    {
                        k3[0] = boolArrLeft[0];
                        k3[1] = boolArrLeft[2];
                        k3[2] = boolArrRight[0];
                        k3[3] = boolArrRight[2];
                    }
                    boolArr = Merge(boolArrLeft, boolArrRight);
                }
                else
                {
                    if (round == 1)
                    {
                        k2[0] = boolArr[0];
                        k2[1] = boolArr[2];
                        k2[2] = boolArr[4];
                        k2[3] = boolArr[6];
                    }
                    else
                    {
                        k4[0] = boolArr[0];
                        k4[1] = boolArr[2];
                        k4[2] = boolArr[4];
                        k4[3] = boolArr[6];
                    }
                    var splitArr = Split(boolArr);
                    boolArrLeft = splitArr.Item1;
                    boolArrRight = splitArr.Item2;
                }
                round++;
            }
            return (k1, k2, k3, k4);
        }
    }
}
