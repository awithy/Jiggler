using Moq;
using NUnit.Framework;
// ReSharper disable InconsistentNaming

namespace Jiggler.Tests
{
    [TestFixture]
    public abstract class JigglerEngineTests
    {
        private JigglerEngine _jigglerEngine = new JigglerEngine();
        private Mock<IAssemblyUpdater> _assemblyUpdater = new Mock<IAssemblyUpdater>();
        private string _assemblyPath = "assemblyPath";

        [SetUp]
        public void SetUp()
        {
            _StubAssemblyUpdaterFactory();
        }

        private void _StubAssemblyUpdaterFactory()
        {
            var assemblyUpdaterFactory = new Mock<IAssemblyUpdaterFactory>();
            assemblyUpdaterFactory.Setup(x => x.Load(_assemblyPath)).Returns(_assemblyUpdater.Object);
            _jigglerEngine.AssemblyUpdaterFactory = assemblyUpdaterFactory.Object;
        }

        [TestFixture]
        public class When_jiggling : JigglerEngineTests
        {
            [SetUp]
            public void When()
            {
                var jigglerArguments = new JigglerArguments {AssemblyPath = _assemblyPath};
                _jigglerEngine.Jiggle(jigglerArguments);
            }

            [Test]
            public void It_should_add_a_call_to_the_jiggle_method_to_every_method_in_the_assembly_in_that_namespace_root()
            {
                _assemblyUpdater.Verify(x => x.UpdateOnDisk());
            }
        }
    }
}