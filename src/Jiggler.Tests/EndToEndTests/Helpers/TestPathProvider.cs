using System;
using System.IO;

namespace Jiggler.Tests.EndToEndTests.Helpers
{
    public class TestPathProvider
    {
        public string GetTestAssemblyBuildPath()
        {
            return Path.Combine(_GetSrcPath(), @"TestAssembly\bin\debug\TestAssembly.exe");
        }

        public string GetTestAssemblyJiggleTestFile()
        {
            return Path.Combine(_GetSrcPath(), @"TestAssembly\bin\debug\TestOutput.txt");
        }

        public string GetJiggleExePath()
        {
            return Path.Combine(_GetSrcPath(), @"JigglerConsole\bin\debug\JigglerConsole.exe");
        }

        private string _GetSrcPath()
        {
            return Path.Combine(Environment.CurrentDirectory, @"..\..\..\");
        }
    }
}