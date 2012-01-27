using System;
using System.Threading;

namespace Jiggler.Jiggles
{
    public static class RandomSleepJiggle
    {
        private static readonly Random _random = new Random();
        private static bool _switch;

        public static void Jiggle()
        {
            _switch = !_switch;
            if (_switch)
                return;

            var sleepLength = 0;
            var nextRand = _random.Next(0, 1000);
            if(nextRand <= 800)
            {
                return;
            }

            if(nextRand <= 950)
            {
                sleepLength = _random.Next(0, 10);
            }
            else if(nextRand <= 999)
            {
                sleepLength = _random.Next(0, 300);
            }
            else
            {
                sleepLength = _random.Next(0, 60000);
            }
            Thread.Sleep(sleepLength);
        }
    }
}
