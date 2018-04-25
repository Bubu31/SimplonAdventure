using System;
using System.Threading;

namespace SimplonAdventureBeta.Helpers
{
    public static class RandomHelper
    {
        private static int seed = Environment.TickCount;

        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref seed))
        );

        private static Random GetThreadRandom()
        {
            return randomWrapper.Value;
        }


        public static int GetRandom(int min, int max)
        {
            return GetThreadRandom().Next(min, max + 1);
        }
    }
}
