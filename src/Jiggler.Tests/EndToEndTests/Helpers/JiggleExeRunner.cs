using System.Diagnostics;

namespace Jiggler.Tests.EndToEndTests.Helpers
{
    public class JiggleExeRunner
    {
        public void Run(JiggleExeRunnerArguments arguments)
        {
            var jiggleExePath = new TestPathProvider().GetJiggleExePath();
            var startInfo = new ProcessStartInfo(jiggleExePath, arguments.ToArgumentsString());
            startInfo.WorkingDirectory = arguments.WorkingDirectory;
            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}