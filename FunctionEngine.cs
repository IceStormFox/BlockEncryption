using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrBlokowyV5._3
{
    public class FunctionEngine
    {
        public Func<bool[], bool[], bool> function1 = (x, k) => x[0] ^ x[0] & x[2] ^ x[1] & x[3] ^ x[1] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[0];
        public Func<bool[], bool[], bool> function2 = (x, k) => x[1] ^ x[0] & x[2] ^ x[0] & x[1] & x[3] ^ x[0] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[1];
        public Func<bool[], bool[], bool> function3 = (x, k) => true ^ x[2] ^ x[0] & x[3] ^ x[0] & x[1] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[2];
        public Func<bool[], bool[], bool> function4 = (x, k) => true ^ x[0] & x[1] ^ x[2] & x[3] ^ x[0] & x[1] & x[3] ^ x[0] & x[2] & x[3] ^ x[0] & x[1] & x[2] & x[3] ^ k[3];
        public static bool[] BitShiftLeft(bool[] boolArr)
        {
            string tempString = "0b" + ConvertExtension.ArrayToString(boolArr);
            uint binNum = uint.Parse(tempString);
            uint shiftedNum = binNum << 1;
            tempString = Convert.ToString(shiftedNum, toBase: 2);
            tempString = tempString.Substring(tempString.Length - 8, 8);
            return ConvertExtension.StringToArray(tempString);
        }
    }
}
