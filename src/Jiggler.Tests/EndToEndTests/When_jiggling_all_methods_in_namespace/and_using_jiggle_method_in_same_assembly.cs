﻿using System;
using System.IO;
using Jiggler.Tests.EndToEndTests.Helpers;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Jiggler.Tests.EndToEndTests.When_jiggling_all_methods_in_namespace
{
    [TestFixture]
    public class When_jiggling_all_methods_in_a_namespace : EndToEndTestBase
    {
        private string _randomStringToPassThroughForTest = Guid.NewGuid().ToString("N");
        private string _outputTestFileContents;

        [SetUp]
        public void Context()
        {
            _testJiggleAssemblyPath = _tmpTestAssemblyPath;
            _jiggleMethod = "TestAssembly.TestJiggle.Jiggle";
            _JiggleTestAssembly();
            _ProduceTestJiggleOutputUsingJiggledTestAssembly();
        }

        private void _JiggleTestAssembly()
        {
            var jiggleArguments = new JiggleExeRunnerArguments
                                      {
                                          AssemblyPath = _tmpTestAssemblyPath,
                                          Namespace = _testAssemblyNamespace,
                                          JiggleAssemblyPath = _testJiggleAssemblyPath,
                                          JiggleMethod = _jiggleMethod,
                                      };
            _jiggleExeRunner.Run(jiggleArguments);
        }

        private void _ProduceTestJiggleOutputUsingJiggledTestAssembly()
        {
            _RunTestAssembly();
            _ReadJiggleTestOutput();
        }

        private void _RunTestAssembly()
        {
            _testAssemblyExeRunner.Run(_tmpTestAssemblyPath, _randomStringToPassThroughForTest);
        }

        private void _ReadJiggleTestOutput()
        {
            var pathToTestOutputFile = _testPathProvider.GetTestAssemblyJiggleTestFile();
            _outputTestFileContents = File.ReadAllText(pathToTestOutputFile);
        }

        [Test]
        public void It_should_add_a_call_to_the_jiggle_method_to_every_method_in_the_system_()
        {
            Assert.That(_outputTestFileContents, Is.EqualTo(_randomStringToPassThroughForTest));
        }
    }
}