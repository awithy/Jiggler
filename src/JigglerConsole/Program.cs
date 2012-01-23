using System;
using System.IO;
using Jiggler;

namespace JigglerConsole
{
    public class Program
    {
        public static IJigglerEngine JigglerEngine = new JigglerEngine();
        public static int Main(string[] args)
        {
            var exitCode = 0;
            try
            {
                _Main(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                File.AppendAllText("Error.txt", ex.ToString());
                exitCode = -1;
            }
            return exitCode;
        }

        private static void _Main(string[] args)
        {
            Console.WriteLine("Jiggler Running");
            var jigglerArgumentsParser = new JigglerArgumentsParser();
            var jigglerArguments = jigglerArgumentsParser.Parse(args);
            JigglerEngine.Jiggle(jigglerArguments);
            Console.WriteLine("Jiggler Complete");
        }
    }
}