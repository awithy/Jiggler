using System;
using System.Threading;

namespace SampleApp
{
    class Program
    {
        private static int _count;
        
        static void Main()
        {
            _StartACountingThread("First thread");

            Thread.Sleep(500);

            _StartACountingThread("Second thread");
        }

        private static void _StartACountingThread(string threadName)
        {
            var parameterizedThreadStart = new ParameterizedThreadStart(_SharedCount);
            var threadOne = new Thread(parameterizedThreadStart);
            threadOne.IsBackground = false;
            threadOne.Start(threadName);
        }

        static void _SharedCount(object threadName)
        {
            while(true)
            {
                _DoSharedCount(threadName);
            }
        }

        private static void _DoSharedCount(object threadName)
        {
            var oldCount = _count;
            _count++;
            Console.WriteLine(threadName + ":" + _count);
            Thread.Sleep(100);
            if (_count != ++oldCount)
                throw new Exception(threadName + ": I fail!");
            Thread.Sleep(1000);
        }
    }
}