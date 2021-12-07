using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandlerTests.TextObjectModelTests.CharacterTests
{
    [TestClass]
    public class PunctuationSymbolClassTests
    {
        [TestMethod]
        public void TestCreatingWithValidParametersLengthThree()
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
        public void TestCreatingWithValidParametersLengthTwo()
        {
            var punctuationMarks = new List<PunctuationMark>
            {
                new PunctuationMark('?'),
                new PunctuationMark('!')
            };

            var punctuationSymbolObject = new PunctuationSymbol(punctuationMarks);

            Assert.IsTrue(punctuationMarks.SequenceEqual(punctuationSymbolObject.Value.ToList()));
        }

        [TestMethod]
        public void TestCreatingWithInvalidParametersPunctuationMarksLengthThreeIsWrong()
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

        [TestMethod]
        public void TestCreatingWithInvalidParametersPunctuationMarksLengthTwoIsWrong()
        {
            var punctuationMarks = new List<PunctuationMark>
            {
                new PunctuationMark('.'),
                new PunctuationMark('.')
            };

            Assert.ThrowsException<ArgumentException>(() => new PunctuationSymbol(punctuationMarks),
                nameof(PunctuationSymbol));
        }

        [TestMethod]
        public void TestCreatingWithInvalidParametersPunctuationMarksIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new PunctuationSymbol(null),
                nameof(PunctuationSymbol.Value));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(4)]
        public void TestCreatingWithInvalidParametersPunctuationSymbolLengthIsInvalid(int length)
        {
            var punctuationMarks = new List<PunctuationMark>(length);

            for (int i = 0; i < length; i++)
            {
                punctuationMarks.Add(new PunctuationMark('.'));
            }

            Assert.ThrowsException<ArgumentException>(() => new PunctuationSymbol(punctuationMarks),
                nameof(PunctuationSymbol));
        }
    }
}
