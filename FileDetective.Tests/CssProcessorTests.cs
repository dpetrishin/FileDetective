using System.Collections.Generic;

using FileDetective.Library.FileProcessorFabric;

using NUnit.Framework;

namespace FileDetective.Tests
{
    [TestFixture]
    public class CssProcessorTests
    {
        [Test]
        [TestCase("test.css", "{}{{}}{{{}}}", "true")]
        [TestCase("test.css", "{}{{}}}", "false")]
        [TestCase("test.css", "}}", "false")]
        [TestCase("test.css", "sdfh{sfdsa{sdf}fsd.}sdf/", "true")]
        public void Tests(string fileName, string input, string expectedResult)
        {
            FileProcessor processor = new CssFileProcessor();
            List<OperationResultModel> result = processor.Process(fileName, input);

            Assert.That(result[0].Result, Is.EqualTo(expectedResult));
        }
    }
}
