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
        private Mock<IILMethod> _methodToUpdate;
        private Mock<IILMethod> _jiggleMethodToFind;
        private string _jiggleMethodNameToFind;
        private string _namespaceToUpdate;

        [SetUp]
        public void SetUp()
        {
            _assemblyUpdater = new AssemblyUpdater(_assemblyILInterface.Object);
            _SetupGetAllNonCtorMethods();
            _SetupFindMethodByName();
        }

        private void _SetupFindMethodByName()
        {
            _jiggleMethodToFind = new Mock<IILMethod>();
            _jiggleMethodNameToFind = "jiggleMethodNameToFind";
            _assemblyILInterface.Setup(x => x.FindMethod(_jiggleMethodNameToFind)).Returns(_jiggleMethodToFind.Object);
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
                _assemblyUpdater.ApplyJiggleToAllMethodsInNamespace(_namespaceToUpdate, _jiggleMethodNameToFind);
            }

            [Test]
            public void It_should_insert_call_to_jiggle_method_at_start_of_each_interface_()
            {
               _methodToUpdate.Verify(x => x.InsertCallAtStart(_jiggleMethodToFind.Object)); 
            }

            [Test]
            public void It_should_save_the_assembly()
            {
               _assemblyILInterface.Verify(x => x.SaveToDisk());
            }
        }
    }
}