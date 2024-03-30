using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFm
{
    internal class RandomIDGenerator
    {
        private static Random random = new Random();

        public static string GenerateRandomID(int length)
        {
            const string chars = "0123456789";
            char[] idChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                idChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(idChars);
        }
    }
}
