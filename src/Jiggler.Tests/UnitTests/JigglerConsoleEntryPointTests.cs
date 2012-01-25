using JigglerConsole;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Jiggler.Tests.UnitTests
{
    [TestFixture]
    public abstract class JigglerConsoleEntryPointTests
    {
        private Mock<IJigglerEngine> _jigglerEngine;
        private ILoggingTestToken _loggingTestToken;

        [SetUp]
        public void SetUp()
        {
            _loggingTestToken = LoggerProvider.ForTest();
            _StubJigglerEngine();
        }

        private void _StubJigglerEngine()
        {
            _jigglerEngine = new Mock<IJigglerEngine>();
            Program.JigglerEngine = _jigglerEngine.Object;
        }

        [TearDown]
        public void TearDown()
        {
            _loggingTestToken.Dispose();
        }

        [TestFixture]
        public class When_running_with_arguments : JigglerConsoleEntryPointTests
        {
            private static int _result;

            [SetUp]
            public void When()
            {
                _RunMainWithArgs();
            }

            private static void _RunMainWithArgs()
            {
                var args = new[] {"assemblyPath", "namespace", "jiggleAssemblyPath", "jiggleMethod"};
                _result = Program.MainSafe(args);
            }

            [Test]
            public void It_should_parse_arguments_and_call_jiggler()
            {
                _jigglerEngine.Verify(x => x.Jiggle(It.Is<JigglerArguments>(y => _AssertArguments(y))));
            }

            private bool _AssertArguments(JigglerArguments jigglerArguments)
            {
                return jigglerArguments.AssemblyToUpdatePath == "assemblyPath"
                    && jigglerArguments.NamespaceToUpdate == "namespace"
                    && jigglerArguments.JiggleMethod == "jiggleMethod";
            }

            [Test]
            public void It_should_return_0_()
            {
                Assert.That(_result, Is.EqualTo(0));
            }
        }

        [TestFixture]
        public class When_exception_thrown_while_running : JigglerConsoleEntryPointTests
        {
            private int _result;

            [SetUp]
            public void When()
            {
                _result = Program.MainSafe(null);
            }

            [Test]
            public void It_should_not_rethrow()
            {
                Assert.True(true);
            }

            [Test]
            public void It_should_return_negative_1()
            {
                Assert.That(_result, Is.EqualTo(-1));
            }
        }
    }
}