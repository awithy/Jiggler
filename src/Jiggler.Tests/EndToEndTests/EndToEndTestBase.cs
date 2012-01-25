using System;
using System.IO;
using Jiggler.Tests.EndToEndTests.Helpers;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Jiggler.Tests.EndToEndTests
{
    [TestFixture]
    [Category("EndToEnd")]
    public abstract class EndToEndTestBase
    {
        protected JiggleExeRunner _jiggleExeRunner;
        protected TestPathProvider _testPathProvider;
        protected TestAssemblyExeRunner _testAssemblyExeRunner;
        protected string _testAssemblyNamespace = "NamespaceToJiggle";
        protected string _testJiggleAssemblyPath;
        protected string _jiggleMethod;
        protected string _tmpTestAssemblyPath;

        [SetUp]
        public void SharedContext()
        {
            _jiggleExeRunner = new JiggleExeRunner();
            _testPathProvider = new TestPathProvider();
            _testAssemblyExeRunner = new TestAssemblyExeRunner();
            _MakeCopyOfTestAssembly();
        }

        private void _MakeCopyOfTestAssembly()
        {
            _tmpTestAssemblyPath = _testPathProvider.GenerateTmpTestAssemblyPath();
            _testPathProvider.CopyTestAssemblyTo(_tmpTestAssemblyPath);
        }

        [TearDown]
        public void TearDown()
        {
            _DisplayErrorFile();
            File.Delete(_tmpTestAssemblyPath);
        }

        private void _DisplayErrorFile()
        {
            var errorFilePath = _testPathProvider.GetErrorFilePath();
            if(File.Exists(errorFilePath))
                Console.WriteLine(File.ReadAllText(errorFilePath));
        }
    }
}