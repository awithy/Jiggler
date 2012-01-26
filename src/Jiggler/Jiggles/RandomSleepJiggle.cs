using System;
using System.Threading;

namespace Jiggler.Jiggles
{
    public static class RandomSleepJiggle
    {
        private static readonly Random _random = new Random();

        public static void Jiggle()
        {
            var sleepLength = 0;
            var typeOfRand = _random.Next(0, 1000);
            if(typeOfRand <= 500)
            {
                return;
            }
            else if(typeOfRand <= 800)
            {
                sleepLength = _random.Next(0, 300);
            }
            else if(typeOfRand <= 990)
            {
                sleepLength = _random.Next(300, 5000);
            }
            else
            {
                sleepLength = _random.Next(5000, 60000);
            }
            Console.WriteLine("Jiggling: " + sleepLength);
            Thread.Sleep(sleepLength);
        }
    }
}
