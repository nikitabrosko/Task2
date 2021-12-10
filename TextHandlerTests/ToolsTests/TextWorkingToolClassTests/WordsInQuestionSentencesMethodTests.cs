using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.Texts;
using TextHandler.TextObjectModel.Words;
using TextHandler.Tools;

namespace TextHandlerTests.ToolsTests.TextWorkingToolClassTests
{
    [TestClass]
    public class WordsInQuestionSentencesMethodTests
    {
        [TestMethod]
        public void TestFindWordsInQuestionSentencesWithValidParameters()
        {
            var wordFirst = new Word(new IWordElement[]
            {
                new Letter('H'),
                new Letter('e'),
                new Letter('l'),
                new Letter('l'),
                new Letter('o')
            });
            var wordSecond = new Word(new IWordElement[]
            {
                new Letter('w'),
                new Letter('o'),
                new Letter('r'),
                new Letter('l'),
                new Letter('d')
            });

            var sentenceFirst = new Sentence(new ISentenceElement[]
            {
                wordFirst,
                new PunctuationMark(','),
                wordSecond,
                new PunctuationMark('?')
            });
            var sentenceSecond = new Sentence(new ISentenceElement[]
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
                new Word(new IWordElement[]
                {
                    new Letter('h'),
                    new Letter('a'),
                    new Letter('v'),
                    new Letter('e')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('f'),
                    new Letter('o'),
                    new Letter('u'),
                    new Letter('r')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('d'),
                    new Letter('s')
                }),
                new PunctuationSymbol(new IPunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var textObject = new Text();
            textObject.Append(sentenceFirst);
            textObject.Append(sentenceSecond);

            IEnumerable<IWord> expectedWords = new Word[]
            {
                wordFirst,
                wordSecond
            };
            var actualWords = TextWorkingTool.FindWordsInQuestionSentences(textObject, 5);

            Assert.IsTrue(expectedWords.ToArray().SequenceEqual(actualWords.ToArray()));
        }

        [TestMethod]
        public void TestFindWordsInQuestionSentencesWithInvalidParametersTextIsNull()
        {
            Text textObject = null;
            var wordLength = 5;

            Assert.ThrowsException<ArgumentNullException>(() =>
                TextWorkingTool.FindWordsInQuestionSentences(textObject, wordLength), nameof(textObject));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void TestFindWordsInQuestionSentencesWithInvalidParametersWordLengthIsInvalid(int wordLength)
        {
            var sentence = new Sentence(new ISentenceElement[]
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
                new Word(new IWordElement[]
                {
                    new Letter('h'),
                    new Letter('a'),
                    new Letter('v'),
                    new Letter('e')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('f'),
                    new Letter('o'),
                    new Letter('u'),
                    new Letter('r')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('d'),
                    new Letter('s')
                }),
                new PunctuationSymbol(new IPunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var textObject = new Text();
            textObject.Append(sentence);

            Assert.ThrowsException<ArgumentException>(
                () => TextWorkingTool.FindWordsInQuestionSentences(textObject, wordLength), nameof(wordLength));
        }
    }
}