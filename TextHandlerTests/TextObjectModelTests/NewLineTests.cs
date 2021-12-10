using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.NewLines;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class NewLineTests
    {
        [TestMethod]
        public void TestCreatingWithValidParametersWithOneCharacter()
        {
            var character = '\n';

            var newLineObject = new NewLine(character);

            Assert.AreEqual(character, newLineObject.Value.First());
        }

        [TestMethod]
        public void TestCreatingWithValidParametersWithTwoCharacters()
        {
            var characterFirst = '\r';
            var characterSecond = '\n';

            var expectedCharacters = new char[]
            {
                characterFirst,
                characterSecond
            };

            var newLineObject = new NewLine(expectedCharacters);

            Assert.AreEqual(expectedCharacters, newLineObject.Value);
        }

        [TestMethod]
        [DataRow('.')]
        [DataRow('a')]
        [DataRow('1')]
        [DataRow('\t')]
        public void TestCreatingWithInvalidParametersOneCharacter(char character)
        {
            Assert.ThrowsException<ArgumentException>(() => new NewLine(character));
        }

        [TestMethod]
        [DataRow('.', '.')]
        [DataRow('a', 'b')]
        [DataRow('1', '2')]
        [DataRow('\t', '\n')]
        public void TestCreatingWithInvalidParametersTwoCharacters(char characterFirst, char characterSecond)
        {
            Assert.ThrowsException<ArgumentException>(() => new NewLine(new char[] { characterFirst, characterSecond }));
        }

        [TestMethod]
        [DataRow('.', '.', '.')]
        [DataRow('a', 'b', 'c')]
        [DataRow('1', '2', '3')]
        [DataRow('\t', '\n', '\r')]
        public void TestCreatingWithInvalidParametersThreeAndMoreCharacters(char characterFirst, char characterSecond, char characterThird)
        {
            Assert.ThrowsException<ArgumentException>(() => new NewLine(new char[] { characterFirst, characterSecond, characterThird }));
        }
    }
}
