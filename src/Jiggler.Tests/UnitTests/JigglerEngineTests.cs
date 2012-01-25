using Jiggler.ILInterface;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Jiggler.Tests.UnitTests
{
    [TestFixture]
    public abstract class JigglerEngineTests
    {
        private JigglerEngine _jigglerEngine;
        private Mock<IAssemblyUpdater> _assemblyUpdater = new Mock<IAssemblyUpdater>();
        private JigglerArguments _jigglerArguments;
        private Mock<IAssemblyUpdaterFactory> _assemblyUpdaterFactory;
        private Mock<IJiggleMethodFactory> _jiggleMethodFactory;
        private Mock<IILMethod> _jiggleMethod;

        [SetUp]
        public void SetUp()
        {
            _SetupJigglerArguments();
            _StubAssemblyUpdaterFactoryForAssemblyToUpdate();
            _StubJiggleMethodFactory();

            _jigglerEngine = new JigglerEngine(_assemblyUpdaterFactory.Object, _jiggleMethodFactory.Object);
        }

        private void _SetupJigglerArguments()
        {
            _jigglerArguments = new JigglerArguments
                                    {
                                        AssemblyToUpdatePath = "assemblyPath",
                                        NamespaceToUpdate = "namespace",
                                        JiggleAssemblyPath = "jiggleAssembly",
                                        JiggleMethod = "jiggleMethod",
                                    };
        }

        private void _StubAssemblyUpdaterFactoryForAssemblyToUpdate()
        {
            _assemblyUpdaterFactory = new Mock<IAssemblyUpdaterFactory>();
            _assemblyUpdaterFactory.Setup(x => x.Create(_jigglerArguments.AssemblyToUpdatePath)).Returns(_assemblyUpdater.Object);
        }

        private void _StubJiggleMethodFactory()
        {
            _jiggleMethodFactory = new Mock<IJiggleMethodFactory>();
            _jiggleMethod = new Mock<IILMethod>();
            _jiggleMethodFactory.Setup(
                x => x.Create(_jigglerArguments.JiggleAssemblyPath, _jigglerArguments.JiggleMethod))
                .Returns(_jiggleMethod.Object);
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
                _assemblyUpdater.Verify(x => x.ApplyJiggleToAllMethodsInNamespace(_jigglerArguments.NamespaceToUpdate, _jiggleMethod.Object));
            }
        }
    }
}