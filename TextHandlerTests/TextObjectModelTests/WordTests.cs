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
        public void TestWordClassCreatingWithValidParameters()
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

        [TestMethod]
        public void TestWordClassCreatingWithInvalidParametersLetterInUppercase()
        {
            var letters = new List<Letter>
            {
                new Letter('w'),
                new Letter('o'),
                new Letter('R'),
                new Letter('D')
            };

            Assert.ThrowsException<ArgumentException>(() => new Word(letters), nameof(Word));
        }

        [TestMethod]
        public void TestWordClassCreatingWithInvalidParametersLettersIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Word(null), nameof(Word.Value));
        }
    }
}