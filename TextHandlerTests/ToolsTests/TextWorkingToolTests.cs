using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;
using TextHandler.Tools;

namespace TextHandlerTests.ToolsTests
{
    [TestClass]
    public class TextWorkingToolTests
    {
        [TestMethod]
        public void DebugTextWorkingToolTest()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file1.txt";

            Parser parser = new Parser();

            Text text = parser.ReadFile(path);

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
                new PunctuationMark('!')
            };

            var result = TextWorkingTool.ReplaceWordsWithSubstring(text, 1, sentenceElements, 5);

            string str = "1";
        }
    }
}
