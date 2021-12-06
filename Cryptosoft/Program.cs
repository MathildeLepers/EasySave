using System;
using System.Collections.Generic;
using System.IO;

namespace CryptoSoft
{
    internal class Program
    {
        static private char[] passcode
        {
            get { return "cesi".ToCharArray(); }
        }
        static int Main(string[] args)
        {
            if (args.Length != 2) return -1;
            var source = args[0];
            var target = args[1];
            if (!File.Exists(source)) return -2;
            byte[] filesource = File.ReadAllBytes(source);
            try
            {

                File.WriteAllBytes(target, xor(filesource));
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;

        }
        static private byte[] xor(byte[] source)
        {
            byte[] result = new byte[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = (byte)(source[i] ^ ((byte)passcode[i % passcode.Length]));

            }
            return result;
        }
    }
}
