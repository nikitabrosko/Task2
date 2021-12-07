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
    public class PunctuationMarkClassTests
    {
        [TestMethod]
        [DataRow('.')]
        [DataRow(',')]
        [DataRow('?')]
        public void TestCreatingWithValidParameters(char punctuationMark)
        {
            var punctuationMarkObject = new PunctuationMark(punctuationMark);

            Assert.AreEqual(punctuationMark, punctuationMarkObject.Value);
        }

        [TestMethod]
        [DataRow('a')]
        [DataRow('1')]
        [DataRow(' ')]
        public void TestCreatingWithInvalidParameters(char punctuationMark)
        {
            Assert.ThrowsException<ArgumentException>(() => new PunctuationMark(punctuationMark),
                nameof(punctuationMark));
        }
    }
}
