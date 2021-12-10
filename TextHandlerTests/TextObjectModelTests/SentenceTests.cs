using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.WhiteSpaces;
using TextHandler.TextObjectModel.Words;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class SentenceTests
    {
        [TestMethod]
        public void TestSentenceClassCreatingWithValidParameters()
        {
            var sentenceElements = new List<ISentenceElement>
            {
                new Word(new IWordElement[]
                {
                    new Letter('S'), 
                    new Letter('e'), 
                    new Letter('n'), 
                    new Letter('t'), 
                    new Letter('e'), 
                    new Letter('n'), 
                    new Letter('c'), 
                    new Letter('e')
                }),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('h'),
                    new Letter('a'),
                    new Letter('v'),
                    new Letter('e')
                }),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('f'),
                    new Letter('o'),
                    new Letter('u'),
                    new Letter('r')
                }),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('d'),
                    new Letter('s')
                }),
                new PunctuationMark('!')
            };

            var sentenceObject = new Sentence(sentenceElements);

            Assert.IsTrue(sentenceElements.SequenceEqual(sentenceObject.Value.ToList()));
        }

        [TestMethod]
        public void TestSentenceClassCreatingWithInvalidParametersElementsIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Sentence(null),
                nameof(ISentence.Value));
        }

        [TestMethod]
        public void TestSentenceClassCreatingWithInvalidParametersElementsLastIsNotPunctuation()
        {
            var sentenceElements = new List<ISentenceElement>
            {
                new Word(new IWordElement[]
                {
                    new Letter('S'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('t'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('c'),
                    new Letter('e')
                })
            };

            Assert.ThrowsException<ArgumentException>(() => new Sentence(sentenceElements),
                nameof(ISentence));
        }

        [TestMethod]
        public void TestSentenceClassCreatingWithInvalidParametersElementsFirstLetterInLowercase()
        {
            var sentenceElements = new List<ISentenceElement>
            {
                new Word(new IWordElement[]
                {
                    new Letter('s'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('t'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('c'),
                    new Letter('e')
                }),
                new PunctuationMark('!')
            };

            Assert.ThrowsException<ArgumentException>(() => new Sentence(sentenceElements),
                nameof(ISentence));
        }

        [TestMethod]
        public void TestSentenceClassCreatingWithInvalidParametersElementsFirstLetterIsPunctuationSymbol()
        {
            var sentenceElements = new List<ISentenceElement>
            {
                new PunctuationSymbol(new IPunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('s'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('t'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('c'),
                    new Letter('e')
                }),
                new PunctuationMark('!')
            };

            Assert.ThrowsException<ArgumentException>(() => new Sentence(sentenceElements),
                nameof(ISentence));
        }
    }
}
