using System;
using System.Security.Cryptography;

namespace RtfGenerator.Generator
{
    public class RandomIndexGenerator : IRandomIndexGenerator
    {
        private static RandomNumberGenerator _random = RandomNumberGenerator.Create();

        private double NextDouble()
        {
            byte[] b = new byte[4];
            _random.GetBytes(b);

            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        public int GetNext(int min, int max)
        {
            return (int)Math.Round(NextDouble() * (max - min - 1)) + min;
        }
    }
}
