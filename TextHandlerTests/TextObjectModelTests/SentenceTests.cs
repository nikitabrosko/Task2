using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class SentenceTests
    {
        [TestMethod]
        public void TestSentenceClassCreating()
        {
            var sentenceElements = new List<ISentenceElement>
            {
                new Word(new Letter[]
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
                new Word(new Letter[]
                {
                    new Letter('h'),
                    new Letter('a'),
                    new Letter('v'),
                    new Letter('e')
                }),
                new Word(new Letter[]
                {
                    new Letter('f'),
                    new Letter('o'),
                    new Letter('u'),
                    new Letter('r')
                }),
                new Word(new Letter[]
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
    }
}
