using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class PunctuationSymbolClassTests
    {
        [TestMethod]
        public void TestCreatingWithValidParametersLengthThree()
        {
            var punctuationMarks = new List<IPunctuationMark>
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
            var punctuationMarks = new List<IPunctuationMark>
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
            var punctuationMarks = new List<IPunctuationMark>
            {
                new PunctuationMark(','),
                new PunctuationMark('.'),
                new PunctuationMark('!')
            };

            Assert.ThrowsException<ArgumentException>(() => new PunctuationSymbol(punctuationMarks),
                nameof(IPunctuationSymbol));
        }

        [TestMethod]
        public void TestCreatingWithInvalidParametersPunctuationMarksLengthTwoIsWrong()
        {
            var punctuationMarks = new List<IPunctuationMark>
            {
                new PunctuationMark('.'),
                new PunctuationMark('.')
            };

            Assert.ThrowsException<ArgumentException>(() => new PunctuationSymbol(punctuationMarks),
                nameof(IPunctuationSymbol));
        }

        [TestMethod]
        public void TestCreatingWithInvalidParametersPunctuationMarksIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new PunctuationSymbol(null),
                nameof(IPunctuationSymbol.Value));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(4)]
        public void TestCreatingWithInvalidParametersPunctuationSymbolLengthIsInvalid(int length)
        {
            var punctuationMarks = new List<IPunctuationMark>(length);

            for (int i = 0; i < length; i++)
            {
                punctuationMarks.Add(new PunctuationMark('.'));
            }

            Assert.ThrowsException<ArgumentException>(() => new PunctuationSymbol(punctuationMarks),
                nameof(IPunctuationSymbol));
        }
    }
}
