using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;
using TextHandler.Tools;

namespace TextHandlerTests.ToolsTests.TextWorkingToolClassTests
{
    [TestClass]
    public class ReplaceWordsWithSubstringMethodTests
    {
        [TestMethod]
        public void TestReplaceWordsWithSubstringWithValidParameters()
        {
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
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationMark('!')
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
                new PunctuationSymbol(new PunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var textObject = new Text();
            textObject.Append(sentenceFirst);
            textObject.Append(sentenceSecond);

            var parser = new ParserToObjectModel();

            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\SubstringTextFile.txt";
            File.WriteAllText(path, "Lorem ipsum.");
            var substring =
                parser.ReadFile(path).Value.First().Value;
            File.Delete(path);

            var expectedResult = new Text();
            expectedResult.Append(new Sentence(new ISentenceElement[]
            {
                new Word(new IWordElement[]
                {
                    new Letter('L'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('e'),
                    new Letter('m')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('i'),
                    new Letter('p'),
                    new Letter('s'),
                    new Letter('u'),
                    new Letter('m')
                }),
                new PunctuationMark('.'),
                new PunctuationMark(','),
                new Word(new IWordElement[]
                {
                    new Letter('L'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('e'),
                    new Letter('m')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('i'),
                    new Letter('p'),
                    new Letter('s'),
                    new Letter('u'),
                    new Letter('m')
                }),
                new PunctuationMark('.'),
                new PunctuationMark('!')
            }));
            expectedResult.Append(sentenceSecond);
            var actualResult = TextWorkingTool.ReplaceWordsWithSubstring(textObject, 0, substring, 5);

            Assert.IsTrue(ComparingTexts(expectedResult, actualResult));

            bool ComparingTexts(Text firstText, Text secondText)
            {
                var firstTextList = firstText.Value.ToList();
                var secondTextList = secondText.Value.ToList();

                if (firstTextList.Count != secondTextList.Count)
                {
                    return false;
                }

                for (int i = 0; i < firstTextList.Count; i++)
                {
                    var firstTextListCurrentSentence = firstTextList[i].Value.ToList();
                    var secondTextListCurrentSentence = secondTextList[i].Value.ToList();

                    if (firstTextListCurrentSentence.Count == secondTextListCurrentSentence.Count)
                    {
                        return !firstTextListCurrentSentence.Where((t, j) => t == secondTextListCurrentSentence[j]).Any();
                    }
                }

                return true;

            }
        }

        [TestMethod]
        public void TestReplaceWordsWithSubstringWithInvalidParametersTextIsNull()
        {
            Text textObject = null;
            var sentenceIndex = 1;

            var parser = new ParserToObjectModel();

            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\SubstringTextFile.txt";
            File.WriteAllText(path, "Lorem ipsum.");
            var substring =
                parser.ReadFile(path).Value.First().Value;
            File.Delete(path);

            var wordLength = 5;

            Assert.ThrowsException<ArgumentNullException>(() =>
                TextWorkingTool.ReplaceWordsWithSubstring(textObject, sentenceIndex, substring, wordLength), nameof(textObject));
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(100)]
        public void TestReplaceWordsWithSubstringWithInvalidParametersSentenceIndexIsInvalid(int sentenceIndex)
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
                new PunctuationSymbol(new PunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var textObject = new Text();
            textObject.Append(sentence);

            var parser = new ParserToObjectModel();

            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\SubstringTextFile.txt";
            File.WriteAllText(path, "Lorem ipsum.");
            var substring =
                parser.ReadFile(path).Value.First().Value;
            File.Delete(path);

            var wordLength = 5;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                TextWorkingTool.ReplaceWordsWithSubstring(textObject, sentenceIndex, substring, wordLength), nameof(sentenceIndex));
        }

        [TestMethod]
        public void TestReplaceWordsWithSubstringWithInvalidParametersSubstringIsNull()
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
                new PunctuationSymbol(new PunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var textObject = new Text();
            textObject.Append(sentence);

            var sentenceIndex = 1;

            IEnumerable<ISentenceElement> substring = null;

            var wordLength = 5;

            Assert.ThrowsException<ArgumentNullException>(() =>
                TextWorkingTool.ReplaceWordsWithSubstring(textObject, sentenceIndex, substring, wordLength), nameof(substring));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void TestReplaceWordsWithSubstringWithInvalidParametersWordLengthIsInvalid(int wordLength)
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
                new PunctuationSymbol(new PunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var textObject = new Text();
            textObject.Append(sentence);

            var sentenceIndex = 1;

            var parser = new ParserToObjectModel();

            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\SubstringTextFile.txt";
            File.WriteAllText(path, "Lorem ipsum.");
            var substring =
                parser.ReadFile(path).Value.First().Value;
            File.Delete(path);

            Assert.ThrowsException<ArgumentException>(() =>
                TextWorkingTool.ReplaceWordsWithSubstring(textObject, sentenceIndex, substring, wordLength), nameof(wordLength));
        }
    }
}
