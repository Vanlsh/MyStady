using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsIPCalculator
{
    public class IpCalculatorInterface
    {
        public static int[] StringToIntArray(string value1, string value2, string value3, string value4)
        {
            int[] result = new int[4];

            string[] values = { value1, value2, value3, value4};

            for (int i = 0; i < 4; i++)
            {
                result[i] = int.Parse(values[i]);
            }

            return result;
        }

        public static BitArray[] StringToBitArray(string value)
        {
            BitArray[] result = new BitArray[4];
            for (int i = 0; i < 4; i++)
            {
                result[i] = new BitArray(8);
            }

            string[] values = value.Split('.');

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (values[i][j] == '1')
                    {
                        result[i][j] = true;
                    }
                }
            }

            return result;
        }

        public static string BitArrayToString(BitArray value)
        {
            string result = string.Empty;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i])
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }

            return result;
        }
        public static int BitArrayToInt(BitArray value)
        {
            var suka = BitArrayToString(value);

            return Convert.ToInt32(suka, 2);
        }
        public static string StrToBineryStr(string value)
        {
            string resultStr = string.Empty;

            if (int.TryParse(value,out int result))
            {
              resultStr = Convert.ToString(result, 2);
            }       
            return resultStr;
        }

       
    }
}
