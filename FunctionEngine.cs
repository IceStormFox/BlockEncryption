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


        public static bool[] RoundEngine(bool[] arrLeft, bool[] arrRight, bool[][] keyItems, int choice)
        {
            uint round = 0;
            if (choice == 1) { keyItems = ReverseKeys(keyItems); }
            while (round < 8)
            {
                bool[] func = FunctionS(arrRight, keyItems[round]);
                bool[] xor = ArraysXor(arrLeft, func);
                var switchArr = SwitchArrays(xor, arrRight);
                arrLeft = switchArr.Item1;
                arrRight = switchArr.Item2;
                round++;
                //main algorythm x 8 rounds
            }
            bool[] result = KeyGeneratorEngine.Merge(arrLeft, arrRight);
            return result;
        }
        public static string Encrypt(bool[] arrLeft, bool[] arrRight, bool[][] keyItems)
        {
            //encrypting algorythm
            bool[] result = RoundEngine(arrLeft, arrRight, keyItems, 0);
            return ConvertExtension.ArrayToString(result);
        }
        public static string Decrypt(bool[] arrLeft, bool[] arrRight, bool[][] keyItems)
        {
            bool[] result = RoundEngine(arrLeft, arrRight, keyItems, 1);
            return ConvertExtension.ArrayToString(result);
            //decrypting algorythm
        }

        public static bool[] FunctionS(bool[] arrRight, bool[] keyItems)
        {
            bool test1 = function1(arrRight, keyItems);
            bool test2 = function2(arrRight, keyItems);
            bool test3 = function3(arrRight, keyItems);
            bool test4 = function4(arrRight, keyItems);

            bool[] func = new bool[]
            {
                function1(arrRight, keyItems),
                function2(arrRight, keyItems),
                function3(arrRight, keyItems),
                function4(arrRight, keyItems)
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
        public static bool[][] ReverseKeys(bool[][] keyItems)
        {
            for (int i = 0; i < keyItems.Length/2; i++) 
            {
                bool[] temp;
                temp = keyItems[i];
                keyItems[i] = keyItems[7-i];
                keyItems[7-i] = temp;
            }
            return keyItems;
        }
    }
}
