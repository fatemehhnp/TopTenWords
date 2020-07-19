using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTenWords.Utility;

namespace TopTenWords.Tests
{
    [TestFixture]
    public class TopWordsTests
    {
        private Mock<IFileReader> _filereader;
        private TopWords _topWords;
        private string url;
        [SetUp]
        public void SetUp()
        {
            _filereader = new Mock<IFileReader>();
            _topWords= new TopWords(_filereader.Object);
            url = "Test.txt";
        }
        //checks if emptyfile case have correct dictionary key and value
        [Test]
        public void TopWords_Emptyfile_ReturnsEmptyDictionaryCase()
        {
           
           
            _filereader.Setup(fr => fr.ReadFileLines(url)).Returns(new List<string>());
            var result = _topWords.GetTopWords(url);
            var expected= new Dictionary<string, int> {
                        {"file is empty",0 }
                    };
            Assert.That(result.Keys, Is.EquivalentTo(expected.Keys));

        }
        //checks if wrongPath case have correct dictionary key and value
        [Test]
        public void TopWords_WrongPath_ReturnsWrongPathDictionaryCase()
        {

            var url = "Test1.txt";
            var result = _topWords.GetTopWords(url);
            var expected = new Dictionary<string, int> {
                        {"file path is not valid",0 }
                    };
            Assert.That(result.Keys, Is.EquivalentTo(expected.Keys));

        }
        [Test]
        //checks if return dictionary is ordered
        public void TopWords_Ordered_returnsOrderedlist()
        {
            var result = _topWords.GetTopWords(url);
            Assert.That(result, Is.Ordered);
        }
    }
}
