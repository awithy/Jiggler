using NUnit.Framework;

namespace Jiggler.Tests
{
    [TestFixture]
    public abstract class JigglerArgumentsParserTests
    {
        private JigglerArgumentsParser _jigglerArgumentsParser;

        [SetUp]
        public void SetUp()
        {
            _jigglerArgumentsParser = new JigglerArgumentsParser();
        }

        [TestFixture]
        public class When_parsing_arguments : JigglerArgumentsParserTests
        {
            private JigglerArguments _jigglerArguments;

            [SetUp]
            public void When()
            {
                var stringArguments = new[] {"assembly", "namespace", "jigglerMethod"};
                _jigglerArguments = _jigglerArgumentsParser.Parse(stringArguments);
            }

            [Test]
            public void It_should_parse_the_assembly_path()
            {
                Assert.That(_jigglerArguments.AssemblyPath, Is.EqualTo("assembly"));
            }

            [Test]
            public void It_should_parse_the_namespace()
            {
                Assert.That(_jigglerArguments.NamespaceToUpdate, Is.EqualTo("namespace"));
            }

            [Test]
            public void It_should_parse_the_jiggler_method()
            {
                Assert.That(_jigglerArguments.JiggleMethod, Is.EqualTo("jigglerMethod"));
            }
        }
    }
}