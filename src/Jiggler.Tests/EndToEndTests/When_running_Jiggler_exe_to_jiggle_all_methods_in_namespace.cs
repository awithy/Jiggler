using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Jiggler.Tests.EndToEndTests
{
    [TestFixture]
    public abstract class JigglerExeEndToEndTests
    {
        [SetUp]
        public void Context()
        {
            
        }

        [TestFixture]
        public class When_jiggling_all_methods_in_a_namespace : JigglerExeEndToEndTests
        {
            
        }
    }
}