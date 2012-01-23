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
        private JigglerArguments _jigglerArguments;

        [SetUp]
        public void SetUp()
        {
            _SetupJigglerArguments();
            _StubAssemblyUpdaterFactory();
        }

        private void _SetupJigglerArguments()
        {
            _jigglerArguments = new JigglerArguments
                                    {
                                        AssemblyPath = "assemblyPath",
                                        NamespaceToUpdate = "namespace",
                                        JiggleMethod = "jiggleMethod",
                                    };
        }

        private void _StubAssemblyUpdaterFactory()
        {
            var assemblyUpdaterFactory = new Mock<IAssemblyUpdaterFactory>();
            assemblyUpdaterFactory.Setup(x => x.Load(_jigglerArguments.AssemblyPath)).Returns(_assemblyUpdater.Object);
            _jigglerEngine.AssemblyUpdaterFactory = assemblyUpdaterFactory.Object;
        }

        [TestFixture]
        public class When_jiggling : JigglerEngineTests
        {
            [SetUp]
            public void When()
            {
                _jigglerEngine.Jiggle(_jigglerArguments);
            }

            [Test]
            public void It_should_load_an_assembly_updater_use_it_to_apply_the_jiggle_to_all_methods_in_namespace_()
            {
                _assemblyUpdater.Verify(x => x.ApplyJiggleToAllMethodsInNamespace(_jigglerArguments.NamespaceToUpdate, _jigglerArguments.JiggleMethod));
            }
        }
    }
}