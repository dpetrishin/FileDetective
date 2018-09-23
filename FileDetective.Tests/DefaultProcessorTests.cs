using System;
using System.Collections.Generic;
using System.Text;

using FileDetective.Library.FileProcessorFabric;

using NUnit.Framework;

namespace FileDetective.Tests
{
    [TestFixture]
    public class DefaultProcessorTests
    {
        [Test]
        [TestCase("test.txt", "dsfldf.rwe.12,:!", "5")]
        public void Tests(string fileName, string input, string expected)
        {
            FileProcessor processor = new DefaultFileProcessor();
            List<OperationResultModel> result = processor.Process(fileName, input);

            Assert.That(result[0].Result, Is.EqualTo(expected));
        }
    }
}
