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

        public static object FunctionS(bool[] arrRight, bool[,] keyItems)
        {
            bool[] tempKeys = new bool[4];
            for (int i = 0;i < 4;i++) { tempKeys[i] = keyItems[0, i]; }
            var func = new bool[]
            {
                //passing the function to xor message and swapping
                function1(arrRight, tempKeys),
                function2(arrRight, tempKeys),
                function3(arrRight, tempKeys),
                function4(arrRight, tempKeys)
            };
            return func;
            //calculating S function
        }

        public static void ArraysXor()
        {
            //xor function for arrays leading to swapping messages
        }
    }
}
