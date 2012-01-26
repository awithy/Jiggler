using System;
using System.Threading;
using NUnit.Framework;

namespace SampleApp
{
    class Program
    {
        private static bool _sharedBool = false;
        
        static void Main(string[] args)
        {
            var threadOne = new Thread(_Count);
            threadOne.IsBackground = false;
            threadOne.Start();

            Thread.Sleep(1000);

            var threadTwo = new Thread(_Count);
            threadTwo.IsBackground = false;
            threadTwo.Start();
        }

        static void _Count()
        {
            while(true)
            {
                var lastReadValue = _sharedBool;
                _sharedBool = !_sharedBool;
                Thread.Sleep(10);
                if(lastReadValue != _sharedBool)
                    throw new Exception("I fail!");
                Thread.Sleep(1000);
            }
        }
    }
}
