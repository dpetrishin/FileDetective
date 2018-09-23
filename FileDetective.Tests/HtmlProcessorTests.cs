using System;
using System.Collections.Generic;

using FileDetective.Library;
using FileDetective.Library.FileProcessorFabric;

using NUnit.Framework;

namespace FileDetective.Tests
{
    [TestFixture]
    public class HtmlProcessorTests
    {

        [Test]
        [TestCase("test.html", "<div><div></div><div></div><div></div></div>", "4")]
        [TestCase("test.html", "<div><div></div><div><div class=\"hidden\"></div><div></div></div>", "5")]
        [TestCase("test.html", "< div>", "1")]
        public void Tests(string fileName, string input, string expectedResult)
        {
            FileProcessor processor = new HtmlFileProcessor();
            List<OperationResultModel> result = processor.Process(fileName, input);

            Assert.That(result[0].Result, Is.EqualTo(expectedResult));
        }
    }
}
