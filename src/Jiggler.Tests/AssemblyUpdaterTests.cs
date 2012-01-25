using System.Collections.Generic;
using Jiggler.ILInterface;
using Moq;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Jiggler.Tests
{
    [TestFixture]
    public abstract class AssemblyUpdaterTests
    {
        private AssemblyUpdater _assemblyUpdater;
        private Mock<IILAssembly> _assemblyILInterface = new Mock<IILAssembly>();
        private Mock<IILMethod> _jiggleMethod = new Mock<IILMethod>();
        private Mock<IILMethod> _methodToUpdate;
        private string _namespaceToUpdate;

        [SetUp]
        public void SetUp()
        {
            _assemblyUpdater = new AssemblyUpdater(_assemblyILInterface.Object);
            _SetupGetAllNonCtorMethods();
        }

        private void _SetupGetAllNonCtorMethods()
        {
            _methodToUpdate = new Mock<IILMethod>();
            var methodsCollection = new List<IILMethod>();
            methodsCollection.Add(_methodToUpdate.Object);
            _namespaceToUpdate = "namespacePrefix";
            _assemblyILInterface.Setup(x => x.FindAllNonCtorMethodsWithPrefix(_namespaceToUpdate)).Returns(methodsCollection);
        }

        [TestFixture]
        public class When_applying_jiggle_to_all_methods : AssemblyUpdaterTests
        {

            [SetUp]
            public void When()
            {
                _assemblyUpdater.ApplyJiggleToAllMethodsInNamespace(_namespaceToUpdate, _jiggleMethod.Object);
            }

            [Test]
            public void It_should_insert_call_to_jiggle_method_at_start_of_each_interface_()
            {
               _methodToUpdate.Verify(x => x.InsertCallAtStart(_jiggleMethod.Object)); 
            }

            [Test]
            public void It_should_save_the_assembly()
            {
               _assemblyILInterface.Verify(x => x.SaveToDisk());
            }
        }
    }
}