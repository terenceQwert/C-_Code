using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace ConsoleApp1.DataType
{
    public static class DataTypeExtMethods
    {
        public static int AddNarrowingChecked(this long lhs, long rhs) => checked((int)(lhs + rhs));
        public static void TestOverflow()
        {
            long lhs = 34000;
            long rhs = long.MaxValue;
            try
            {
                int result = lhs.AddNarrowingChecked(rhs);

            }
            catch( OverflowException)
            {
                Console.WriteLine("cannot add each other");
            }
        }
    }
    public class DataEncoding
    {
        public static void TestBinaryToAscii_Unicode()
        {
            byte[] asciiCharacterArray = { 128, 200};
            string asciiCharacters = Encoding.ASCII.GetString(asciiCharacterArray);

            byte[] unicodeCharacterArray = { 128, 00, 83, 00, 111, 0, 117, 0, 124, 0, 99, 0 };
            string unicodeCharacters = Encoding.Unicode.GetString(unicodeCharacterArray);
        }
        public static void TestParser()
        {
            string str = "43";
            byte result = 0;
            if(byte.TryParse(str, System.Globalization.NumberStyles.AllowHexSpecifier, System.Globalization.NumberFormatInfo.CurrentInfo,
                out result))
            {
                Console.WriteLine($"=== {result.ToString()}==");
            }
            else
            {
                // exception here
            }
        }
    }
    
}
