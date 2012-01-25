using System;
using System.IO;

namespace Jiggler.Tests.EndToEndTests.Helpers
{
    public class TestPathProvider
    {
        public string GenerateTmpTestAssemblyPath()
        {
            return Path.Combine(_GetSrcPath(), @"TestAssembly\bin\debug\TestAssembly_" + Guid.NewGuid().ToString("N").Substring(0, 5) + ".exe");
        }

        private string _GetTestAssemblyBuildPath()
        {
            return Path.Combine(_GetSrcPath(), @"TestAssembly\bin\debug\TestAssembly.exe");
        }

        public void CopyTestAssemblyTo(string newPath)
        {
            File.Copy(_GetTestAssemblyBuildPath(), newPath);
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
            var srcPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\");
            var directoryInfo = new DirectoryInfo(srcPath);
            return directoryInfo.FullName;
        }

        public string GetErrorFilePath()
        {
            return Path.Combine(_GetSrcPath(), @"TestAssembly\bin\debug\Error.txt");
        }
    }
}