using Jiggler;

namespace JigglerConsole
{
    public class Program
    {
        public static IJigglerEngine JigglerEngine = new JigglerEngine();
        public static void Main(string[] args)
        {
            var jigglerArgumentsParser = new JigglerArgumentsParser();
            var jigglerArguments = jigglerArgumentsParser.Parse(args);
            JigglerEngine.Jiggle(jigglerArguments);
        }
    }
}
