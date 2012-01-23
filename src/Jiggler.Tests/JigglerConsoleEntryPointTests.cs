using JigglerConsole;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Jiggler.Tests
{
    [TestFixture]
    public abstract class JigglerConsoleEntryPointTests
    {
        [TestFixture]
        public class When_running_with_arguments : JigglerConsoleEntryPointTests
        {
            private Mock<IJigglerEngine> _jigglerEngine;

            [SetUp]
            public void When()
            {
                _StubJigglerEngine();
                _RunMainWithArgs();
            }

            private static void _RunMainWithArgs()
            {
                var args = new[] {"assemblyPath", "namespace", "jiggleMethod"};
                Program.Main(args);
            }

            private void _StubJigglerEngine()
            {
                _jigglerEngine = new Mock<IJigglerEngine>();
                Program.JigglerEngine = _jigglerEngine.Object;
            }

            [Test]
            public void It_should_parse_arguments_and_call_jiggler()
            {
                _jigglerEngine.Verify(x => x.Jiggle(It.Is<JigglerArguments>(y => _AssertArguments(y))));
            }

            private bool _AssertArguments(JigglerArguments jigglerArguments)
            {
                return jigglerArguments.AssemblyPath == "assemblyPath"
                    && jigglerArguments.Namespace == "namespace"
                    && jigglerArguments.JiggleMethod == "jiggleMethod";
            }
        }
    }
}