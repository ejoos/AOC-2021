using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC16
{
    class Decoder
    {
        //0 = 0000
        //1 = 0001
        //2 = 0010
        //3 = 0011
        //4 = 0100
        //5 = 0101
        //6 = 0110
        //7 = 0111
        //8 = 1000
        //9 = 1001
        //A = 1010
        //B = 1011
        //C = 1100
        //D = 1101
        //E = 1110
        //F = 1111
        //D2FE28
        //D    2    F    E    2    8
        //1101 0010 1111 1110 0010 1000
        //110100101111111000101000
        //VVVTTTAAAAABBBBBCCCCC
        internal void Parse(string lineData)
        {

            var bits = ToBitArray(lineData);

        }

        private BitArray ToBitArray(string hexString)
        {
            var bytes = Convert.FromHexString(hexString);
            return new BitArray(bytes);
        }


    }
}
