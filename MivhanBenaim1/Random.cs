using System;
using System.Collections.Generic;
using System.Text;

namespace MivhanBenaim1
{
    public static class StaticRandom
    {
        private static  Random _random = new Random();

        public static int Next(int from, int to)
        {
            return _random.Next(from, to);
        }

        public static int Next(int to)
        {
            return _random.Next(to);
        }
    }
}
