using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void TestWordClassCreatingWithValidParametersDefaultWord()
        {
            var wordElements = new List<IWordElement>
            {
                new Letter('w'),
                new Letter('o'),
                new Letter('r'),
                new Letter('d')
            };

            var wordObject = new Word(wordElements);

            Assert.IsTrue(wordElements.SequenceEqual(wordObject.Value.ToList()));
        }

        [TestMethod]
        public void TestWordClassCreatingWithValidParametersDoubleWord()
        {
            var wordElements = new List<IWordElement>
            {
                new Letter('w'),
                new Letter('o'),
                new Letter('r'),
                new Letter('d'),
                new PunctuationMark('-'),
                new Letter('w'),
                new Letter('o'),
                new Letter('r'),
                new Letter('d')
            };

            var wordObject = new Word(wordElements);

            Assert.IsTrue(wordElements.SequenceEqual(wordObject.Value.ToList()));
        }

        [TestMethod]
        public void TestWordClassCreatingWithInvalidParametersPunctuationMarkInStart()
        {
            var wordElements = new List<IWordElement>
            {
                new PunctuationMark('-'),
                new Letter('w'),
                new Letter('o'),
                new Letter('r'),
                new Letter('d')
            };

            Assert.ThrowsException<ArgumentException>(() => new Word(wordElements), nameof(Word));
        }

        [TestMethod]
        public void TestWordClassCreatingWithInvalidParametersLettersIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Word(null), nameof(Word.Value));
        }

        [TestMethod]
        public void TestWordClassCreatingWithInvalidParametersLettersCountIsZero()
        {
            Assert.ThrowsException<ArgumentException>(() => new Word(Array.Empty<Letter>()), nameof(Word.Value));
        }
    }
}