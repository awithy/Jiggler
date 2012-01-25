// ReSharper disable CheckNamespace

using System;

namespace NamespaceToJiggle
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new TestAssemblyArguments(args);
            TestAssembly.TestJiggle.TestStringToPassThrough = arguments.GetStringToPassThrough();
            AnotherTestAssembly.AnotherTestJiggle.TestStringToPassThrough = arguments.GetStringToPassThrough();
            _TestMethod();
        }

        private static void _TestMethod()
        {
            //TestAssembly.TestJiggle.Jiggle();  -- This is the line we are trying to add in the test.
            //AnotherTestAssembly.AnotherTestJiggle.Jiggle();
            Console.WriteLine("Method to jiggle");
        }
    }

    public class TestAssemblyArguments
    {
        private readonly string _stringToPassThrough;

        public TestAssemblyArguments(string[] args)
        {
            _stringToPassThrough = args[0];
        }

        public string GetStringToPassThrough()
        {
            return _stringToPassThrough;
        }
    }
}
