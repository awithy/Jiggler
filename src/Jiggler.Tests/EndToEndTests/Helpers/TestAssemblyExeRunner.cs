using System.Diagnostics;
using System.IO;

namespace Jiggler.Tests.EndToEndTests.Helpers
{
    public class TestAssemblyExeRunner
    {
        public void Run(string testAssemblyExePath, string stringToPassThrough)
        {
            if(!File.Exists(testAssemblyExePath))
                throw new FileNotFoundException("TestAssembly.exe not found");
            var startInfo = new ProcessStartInfo(testAssemblyExePath, stringToPassThrough);
            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}