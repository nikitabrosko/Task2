using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.Texts;
using TextHandler.TextObjectModel.WhiteSpaces;
using TextHandler.TextObjectModel.Words;
using TextHandler.Tools;

namespace TextHandlerTests.ToolsTests.TextWorkingToolClassTests
{
    [TestClass]
    public class RemoveWordsWithConsonantLetterMethodTests
    {
        [TestMethod]
        public void TestRemoveWordsThatStartsWithConsonantLetterWithValidParameters()
        {
            var wordFirst = new Word(new IWordElement[]
            {
                new Letter('W'),
                new Letter('o'),
                new Letter('r'),
                new Letter('d'),
                new Letter('s')
            });
            var wordSecond = new Word(new IWordElement[]
            {
                new Letter('h'),
                new Letter('a'),
                new Letter('v'),
                new Letter('e')
            });
            var wordThird = new Word(new IWordElement[]
            {
                new Letter('f'),
                new Letter('o'),
                new Letter('u'),
                new Letter('r')
            });
            var punctuationSymbol = new PunctuationSymbol(new IPunctuationMark[]
            {
                new PunctuationMark('.'),
                new PunctuationMark('.'),
                new PunctuationMark('.')
            });

            var sentenceFirst = new Sentence(new ISentenceElement[]
            {
                new Word(new IWordElement[]
                {
                    new Letter('H'),
                    new Letter('e'),
                    new Letter('l'),
                    new Letter('l'),
                    new Letter('o')
                }),
                new PunctuationMark(','),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationMark('?')
            });
            var sentenceSecond = new Sentence(new ISentenceElement[]
            {
                wordFirst,
                new WhiteSpace(' '),
                wordSecond,
                new WhiteSpace(' '),
                wordThird,
                punctuationSymbol
            });

            var textObject = new Text();
            textObject.Append(sentenceFirst);
            textObject.Append(sentenceSecond);

            var expectedTextObject = new Text();
            expectedTextObject.Append(new Sentence(new ISentenceElement[]
            {
                new Word(new IWordElement[]
                {
                    new Letter('H'),
                    new Letter('a'),
                    new Letter('v'),
                    new Letter('e')
                }),
                new WhiteSpace(' '),
                wordThird,
                punctuationSymbol
            }));
            var actualTextObject = TextWorkingTool.RemoveWordsThatStartsWithConsonantLetter(textObject, 5);

            Assert.IsTrue(expectedTextObject.GetStringRepresentation().Equals(actualTextObject.GetStringRepresentation()));
        }

        [TestMethod]
        public void TestRemoveWordsThatStartsWithConsonantLetterWithInvalidParametersTextIsNull()
        {
            Text text = null;
            var wordLength = 5;

            Assert.ThrowsException<ArgumentNullException>(() =>
                TextWorkingTool.RemoveWordsThatStartsWithConsonantLetter(text, wordLength), nameof(text));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void TestRemoveWordsThatStartsWithConsonantLetterWithInvalidParametersWordLengthIsInvalid(int wordLength)
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
