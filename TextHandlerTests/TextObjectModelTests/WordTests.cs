using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.SpellingMarks;
using TextHandler.TextObjectModel.Words;

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
                new SpellingMark('-'),
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
                new SpellingMark('-'),
                new Letter('w'),
                new Letter('o'),
                new Letter('r'),
                new Letter('d')
            };

            Assert.ThrowsException<ArgumentException>(() => new Word(wordElements), nameof(IWord));
        }

        [TestMethod]
        public void TestWordClassCreatingWithInvalidParametersLettersIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Word(null), nameof(IWord.Value));
        }

        [TestMethod]
        public void TestWordClassCreatingWithInvalidParametersLettersCountIsZero()
        {
            Assert.ThrowsException<ArgumentException>(() => new Word(Array.Empty<ILetter>()), nameof(IWord.Value));
        }
    }
}