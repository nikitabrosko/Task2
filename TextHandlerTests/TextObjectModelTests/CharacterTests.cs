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
        public void TestLetterClassCreating(char letter)
        {
            var letterObject = new Letter(letter);

            Assert.AreEqual(letter, letterObject.Value);
        }

        [TestMethod]
        [DataRow('.')]
        [DataRow(',')]
        [DataRow('?')]
        public void TestPunctuationMarkClassCreating(char punctuationMark)
        {
            var punctuationMarkObject = new PunctuationMark(punctuationMark);

            Assert.AreEqual(punctuationMark, punctuationMarkObject.Value);
        }

        [TestMethod]
        public void TestPunctuationSymbolClassCreating()
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
    }
}