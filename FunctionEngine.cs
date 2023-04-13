using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrBlokowyV5._3
{
    public class FunctionEngine
    {
        private readonly static Func<bool[], bool[], bool> function1 = (x, k) => x[0] ^ x[0] & x[2] ^ x[1] & x[3] ^ x[1] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[0];
        private readonly static Func<bool[], bool[], bool> function2 = (x, k) => x[1] ^ x[0] & x[2] ^ x[0] & x[1] & x[3] ^ x[0] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[1];
        private readonly static Func<bool[], bool[], bool> function3 = (x, k) => true ^ x[2] ^ x[0] & x[3] ^ x[0] & x[1] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[2];
        private readonly static Func<bool[], bool[], bool> function4 = (x, k) => true ^ x[0] & x[1] ^ x[2] & x[3] ^ x[0] & x[1] & x[3] ^ x[0] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[3];

        public static bool[] BitShiftLeft(bool[] boolArr)
        {
            string tempString = "0b" + ConvertExtension.ArrayToString(boolArr);
            uint binNum = uint.Parse(tempString);
            uint shiftedNum = binNum << 1;
            tempString = Convert.ToString(shiftedNum, toBase: 2);
            tempString = tempString.Substring(tempString.Length - 8, 8);
            return ConvertExtension.StringToArray(tempString);
        }
        public static void RoundEngine()
        {
            //main algorythm x 8 rounds
        }
        public static void Encrypt(bool[] arrLeft)
        {
            //encrypting algorythm
            for (int i = 0; i < 4; i++)
            {

            }
        }
        public static void Decrypt()
        {
            //decrypting algorythm
        }

        public static object FunctionS(bool[] arrRight, bool[][] keyItems)
        {
            var func = new bool[]
            {
                function1(arrRight, keyItems[0]),
                function2(arrRight, keyItems[0]),
                function3(arrRight, keyItems[0]),
                function4(arrRight, keyItems[0])
            };
            return func;
        }

        public static bool[] ArraysXor(bool[] arrLeft, bool[] arrFunc)
        {
            bool[] tempArr = new bool[4];
            for (int i = 0; i < 4;i++) { tempArr[i] = arrLeft[i] ^ arrFunc[i]; }
            return tempArr;
        }
        public static (bool[], bool[]) SwitchArrays(bool[] arrLeft, bool[] arrRight)
        {
            bool[] temp; //= new bool[4];
            temp = arrLeft;
            arrLeft = arrRight;
            arrRight = temp;
            return (arrLeft, arrRight);
        }
    }
}
