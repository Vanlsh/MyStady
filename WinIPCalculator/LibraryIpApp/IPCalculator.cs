using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryIpApp
{
    public class IPCalculator
    {
        private BitArray[] ipAdressOctets;
        private BitArray[] networkMaskOctets;

        public int MaskPrefixes()
        {
            int maskPrefixes = 0;  
            foreach (var item in networkMaskOctets)
            {
                for(int i = 0;i < item.Length;i++)
                {
                    if(item[i] == true)
                    {
                        maskPrefixes++;
                    }
                    if (item[i] == false)
                    {
                       return maskPrefixes;
                    }
                }
                
            }
         
            return maskPrefixes;
        }
        public int NumberOfHosts()
        {
            int num = (32 - MaskPrefixes());
            return num;
        }
        public IPCalculator()
        {
            ipAdressOctets = new BitArray[4];

            for (int i = 0; i < ipAdressOctets.Length; i++)
            {
                ipAdressOctets[i] = new BitArray(8);
            }

            networkMaskOctets = new BitArray[4];

            for (int i = 0; i < networkMaskOctets.Length; i++)
            {
                networkMaskOctets[i] = new BitArray(8);
            }
        }

        public BitArray[] GetNetworkAdress()
        {
            BitArray[] result = new BitArray[4];

            for (int i = 0; i < ipAdressOctets.Length; i++)
            {
                result[i] = new BitArray(8);
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (networkMaskOctets[i][j])
                    {
                        result[i][j] = ipAdressOctets[i][j];
                    }
                    else
                    {
                        result[i][j] = false;
                    }
                }
            }

            return result;
        }
        public BitArray[] GetHostMin()
        {
            BitArray[] result = GetNetworkAdress();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!networkMaskOctets[i][j])
                    {
                        result[i][j] = false;
                    }
                }
            }

            result[3][7] = true;

            return result;
        }

        public BitArray[] GetHostMax()
        {
            BitArray[] result = GetNetworkAdress();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!networkMaskOctets[i][j])
                    {
                        result[i][j] = true;
                    }
                }
            }

            result[3][7] = false;

            return result;
        }

        public void SetIpAddres(BitArray[] ipAdress)
        {
            for (int i = 0; i < 4; i++)
            {
                ipAdressOctets[i] = new BitArray(ipAdress[i]);
            }
        }

        private BitArray IntToBitArray(int value)
        {
            if (value > 255 | value < 0)
            {
                throw new InvalidOperationException("Vaue must be value > 255 | value < 0.");
            }

            BitArray result = new BitArray(8);

            if (value == 0)
            {
                return result;
            }

            int i = 7;
            while (value != 1)
            {

                if (value % 2 == 1)
                {
                    result[i] = true;
                }
                i--;

                value /= 2;
            }
            result[i] = true;

            return result;
        }

        public void SetIpAddres(int[] ipAdress)
        {
            for (int i = 0; i < 4; i++)
            {
                ipAdressOctets[i] = IntToBitArray(ipAdress[i]);
            }
        }

        public void SetNetworkMask(BitArray[] networkMask)
        {
            for (int i = 0; i < 4; i++)
            {
                networkMaskOctets[i] = new BitArray(networkMask[i]);
            }
        }

        public void SetNetworkMask(int[] networkMask)
        {
            for (int i = 0; i < 4; i++)
            {
                networkMaskOctets[i] = IntToBitArray(networkMask[i]);
            }
        }

        private BitArray StringToBitArray(string value)
        {
            BitArray result = new BitArray(8);

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '0')
                {
                    result[i] = false;
                }

                if (value[i] == '1')
                {
                    result[i] = true;
                }
            }

            return result;
        }


    }
}
