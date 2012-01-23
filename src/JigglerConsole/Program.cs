using System;
using Jiggler;

namespace JigglerConsole
{
    public class Program
    {
        public static IJigglerEngine JigglerEngine = new JigglerEngine();
        public static int Main(string[] args)
        {
            try
            {
                _Main(args);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
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