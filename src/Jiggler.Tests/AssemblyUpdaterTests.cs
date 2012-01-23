using NUnit.Framework;
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Jiggler.Tests
{
    [TestFixture]
    public abstract class AssemblyUpdaterTests
    {
        //private AssemblyUpdater _assemblyUpdater;

        [SetUp]
        public void SetUp()
        {
            //_assemblyUpdater = new AssemblyUpdater("assemblyPath");
        }

        [TestFixture]
        public class When_applying_jiggle_to_all_methods : AssemblyUpdaterTests
        {
            [SetUp]
            public void When()
            {
                //var namespaceToUpdate = "namespace";
                //var jiggleMethod = "jiggleMethod";
                //_assemblyUpdater.ApplyJiggleToAllMethodsInNamespace(namespaceToUpdate, jiggleMethod);
            }

            [Test]
            public void It_should()
            {
                //TBC
            }
        }
    }
}
