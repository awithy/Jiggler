using System;
using System.Threading;

namespace Jiggler.Jiggles
{
    public class RandomSleepJiggle : IJiggle
    {
        private static readonly Random Random = new Random();

        public void Jiggle()
        {
            var sleepLength = 0;
            var typeOfRand = Random.Next(0, 1000);
            if(typeOfRand <= 500)
            {
                return;
            }
            else if(typeOfRand <= 800)
            {
                sleepLength = Random.Next(0, 300);
            }
            else if(typeOfRand <= 990)
            {
                sleepLength = Random.Next(300, 5000);
            }
            else
            {
                sleepLength = Random.Next(5000, 60000);
            }
            Thread.Sleep(sleepLength);
        }
    }
}
