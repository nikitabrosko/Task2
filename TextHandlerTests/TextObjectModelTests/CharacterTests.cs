using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        [DataRow('a')]
        [DataRow('b')]
        [DataRow('c')]
        public void TestLetterClassCreatingWithValidParameters(char letter)
        {
            var letterObject = new Letter(letter);

            Assert.AreEqual(letter, letterObject.Value);
        }

        [TestMethod]
        [DataRow('.')]
        [DataRow(' ')]
        [DataRow('1')]
        public void TestLetterClassCreatingWithInvalidParameters(char letter)
        {
            Assert.ThrowsException<ArgumentException>(() => new Letter(letter),
                nameof(letter));
        }

        [TestMethod]
        [DataRow('.')]
        [DataRow(',')]
        [DataRow('?')]
        public void TestPunctuationMarkClassCreatingWithValidParameters(char punctuationMark)
        {
            var punctuationMarkObject = new PunctuationMark(punctuationMark);

            Assert.AreEqual(punctuationMark, punctuationMarkObject.Value);
        }

        [TestMethod]
        [DataRow('a')]
        [DataRow('1')]
        [DataRow(' ')]
        public void TestPunctuationMarkClassCreatingWithInvalidParameters(char punctuationMark)
        {
            Assert.ThrowsException<ArgumentException>(() => new PunctuationMark(punctuationMark),
                nameof(punctuationMark));
        }

        [TestMethod]
        public void TestPunctuationSymbolClassCreatingWithValidParameters()
        {
            var punctuationMarks = new List<PunctuationMark>
            {
                new PunctuationMark('.'), 
                new PunctuationMark('.'), 
                new PunctuationMark('.')
            };

            var punctuationSymbolObject = new PunctuationSymbol(punctuationMarks);

            Assert.IsTrue(punctuationMarks.SequenceEqual(punctuationSymbolObject.Value.ToList()));
        }

        [TestMethod]
        public void TestPunctuationSymbolClassCreatingWithInvalidParameters()
        {
            var punctuationMarks = new List<PunctuationMark>
            {
                new PunctuationMark(','),
                new PunctuationMark('.'),
                new PunctuationMark('!')
            };

            Assert.ThrowsException<ArgumentException>(() => new PunctuationSymbol(punctuationMarks),
                nameof(PunctuationSymbol));
        }
    }
}