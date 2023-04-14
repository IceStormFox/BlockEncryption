namespace SzyfrBlokowyV5._3
{
    public class FunctionEngine
    {
        private readonly static Func<bool[], bool[], bool> function1 = (x, k) => x[0] ^ x[0] & x[2] ^ x[1] & x[3] ^ x[1] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[0];
        private readonly static Func<bool[], bool[], bool> function2 = (x, k) => x[1] ^ x[0] & x[2] ^ x[0] & x[1] & x[3] ^ x[0] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[1];
        private readonly static Func<bool[], bool[], bool> function3 = (x, k) => true ^ x[2] ^ x[0] & x[3] ^ x[0] & x[1] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[2];
        private readonly static Func<bool[], bool[], bool> function4 = (x, k) => true ^ x[0] & x[1] ^ x[2] & x[3] ^ x[0] & x[1] & x[3] ^ x[0] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[3];

        #region AlgorythmModifiers
        public static bool[] ArraysXor(bool[] arrLeft, bool[] arrFunc)
        {
            bool[] tempArr = new bool[4];
            for (int i = 0; i < 4; i++) { tempArr[i] = arrLeft[i] ^ arrFunc[i]; }
            return tempArr;
        }
        public static (bool[], bool[]) SwitchArrays(bool[] arrLeft, bool[] arrRight)
        {
            (arrLeft, arrRight) = (arrRight, arrLeft);
            return (arrLeft, arrRight);
        }

        public static bool[][] ReverseKeys(bool[][] keyItems)
        {
            for (int i = 0; i < keyItems.Length / 2; i++)
            {
                (keyItems[7 - i], keyItems[i]) = (keyItems[i], keyItems[7 - i]);
            }
            return keyItems;
        }
        #endregion

        public static string RoundEngine(bool[] arrLeft, bool[] arrRight, bool[][] keyItems, int choice)
        {
            if (choice == 2) keyItems = ReverseKeys(keyItems);

            for (int round = 0; round < 8; round++)
            {
                bool[] func = FunctionS(arrRight, keyItems[round]);
                bool[] xor = ArraysXor(arrLeft, func);

                if (round < 7) (arrLeft, arrRight) = SwitchArrays(xor, arrRight);
                else arrLeft = xor;
            }

            return ConvertExtension.ArrayToString(KeyGeneratorEngine.Merge(arrLeft, arrRight));
        }

        public static bool[] FunctionS(bool[] arrRight, bool[] keyItems)
        {
            bool[] func = new bool[]
            {
                function1(arrRight, keyItems),
                function2(arrRight, keyItems),
                function3(arrRight, keyItems),
                function4(arrRight, keyItems)
            };
            return func;
        }

    }
}
