using System;
using System.Diagnostics;
using Jiggler;
using Jiggler.ILInterface;

namespace JigglerConsole
{
    public class Program
    {
        public static IJigglerEngine JigglerEngine = new JigglerEngine(new AssemblyUpdaterFactory(),
                                                                       new JiggleMethodFactory(
                                                                           new CecilILAssemblyFactory()));
        public static ILogger Log = LoggerProvider.GetLogger(typeof (Program));

        public static int Main(string[] args)
        {
            LoggerProvider.EnableLogging();
            return MainSafe(args);
        }

        public static int MainSafe(string[] args)
        {
            Debugger.Break();
            if(args.Length == 0)
            {
                _Usage();
                return 0;
            }
            var exitCode = 0;
            try
            {
                _ParseArgsAndExecuteJigglerEngine(args);
            }
            catch (Exception ex)
            {
                Log.Error(ex.GetType().Name + " thrown while running Jiggler.", ex);
                exitCode = -1;
            }
            //Console.ReadKey();
            return exitCode;
        }

        private static void _Usage()
        {
            Console.WriteLine("Jiggler Usage:");
            Console.WriteLine("JigglerConsole.exe <Assembly-to-jiggle> <Namespace-to-jiggle> <Jiggle-assembly> <Jiggle-method>");
        }

        private static void _ParseArgsAndExecuteJigglerEngine(string[] args)
        {
            Log.Info("Jiggler running");
            var jigglerArgumentsParser = new JigglerArgumentsParser();
            var jigglerArguments = jigglerArgumentsParser.Parse(args);
            JigglerEngine.Jiggle(jigglerArguments);
            Log.Info("Jiggler complete");
        }
    }
}