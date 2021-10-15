using System.Collections;

namespace IPCalculatorConsoleApp
{
    class IPCalculatorDemo
    {
        public static int[] StringToIntArray(string value)
        {
            int[] result = new int[4];

            string[] values = value.Split('.');

            for (int i = 0; i < 4; i++)
            {
                result[i] = int.Parse(values[i]);
            }

            return result;
        }

        public static BitArray[] StringToBitArray(string value)
        {
            BitArray[] result =new BitArray[4];
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

            for(int i = 0;i < value.Length; i++)
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
        static void Main()
        {

            IPCalculator calculator = new IPCalculator();

            bool Binary = false;

            if(Binary)
            {
                string ip = "11000000.10101000.00000001.00011011";
                string mask = "11111111.11111111.11111111.00000000";

                BitArray[] ipInput = StringToBitArray(ip);
                BitArray[] maskInput = StringToBitArray(mask);


                calculator.SetIpAddres(ipInput);
                calculator.SetNetworkMask(maskInput);

                Console.WriteLine("IP:\t\t " + ip);
                Console.WriteLine("Mask:\t\t " + mask);
            }
            else
            {
                string ip = "192.198.35.12";
                string mask = "255.255.255.0";

                int[] ipInput = StringToIntArray(ip);
                int[] maskInput = StringToIntArray(mask);


                calculator.SetIpAddres(ipInput);
                calculator.SetNetworkMask(maskInput);

                Console.WriteLine("IP:\t\t " + ip);
                Console.WriteLine("Mask:\t\t " + mask);
            }



            BitArray[] NetworkAdress = calculator.GetNetworkAdress();
            BitArray[] HostMin = calculator.GetHostMin();
            BitArray[] HostMax = calculator.GetHostMax();



            Console.Write("Network Adress:\t ");
            foreach (BitArray i in NetworkAdress)
            {
                Console.Write(BitArrayToString(i) + ".");
            }

            Console.Write('\n');

            Console.Write("HostMin:\t ");
            foreach (BitArray i in HostMin)
            {
                Console.Write(BitArrayToString(i) + ".");
            }

            Console.Write('\n');

            Console.Write("HostMax:\t ");
            foreach (BitArray i in HostMax)
            {
                Console.Write(BitArrayToString(i) + ".");
            }

            Console.Write('\n');
          

        }
    }
}