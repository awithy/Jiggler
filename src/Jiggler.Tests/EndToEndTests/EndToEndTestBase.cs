using Jiggler.Tests.EndToEndTests.Helpers;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Jiggler.Tests.EndToEndTests
{
    [TestFixture]
    public abstract class EndToEndTestBase
    {
        protected JiggleExeRunner _jiggleExeRunner;
        protected TestPathProvider _testPathProvider;
        protected TestAssemblyExeRunner _testAssemblyExeRunner;
        protected string _testAssemblyNamespace = "NamespaceToJiggle";
        protected string _testJiggleAssemblyPath;
        protected string _jiggleMethod;

        [SetUp]
        public void SharedContext()
        {
            _jiggleExeRunner = new JiggleExeRunner();
            _testPathProvider = new TestPathProvider();
            _testAssemblyExeRunner = new TestAssemblyExeRunner();
        }
    }
}