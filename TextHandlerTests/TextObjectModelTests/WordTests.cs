using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void TestWordClassCreating()
        {
            var letters = new List<Letter>
            {
                new Letter('w'),
                new Letter('o'),
                new Letter('r'),
                new Letter('d')
            };

            var wordObject = new Word(letters);

            Assert.IsTrue(letters.SequenceEqual(wordObject.Value.ToList()));
        }
    }
}
