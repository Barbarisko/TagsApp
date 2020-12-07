using Moq;
using NUnit.Framework;
using System;
using TagsApp;

namespace TagsAppTests
{
    [TestFixture]
    public class UserInputControllerTests
    {
        private UserInputController u;
        [SetUp]
        public void Setup()
        {
            u = new UserInputController();
        }

        [TestCase("2")]
        [TestCase("1")]
        [TestCase("3")]
        public void ChooseFieldType_inputString_UintReturn(string value)
        {
            uint expected = Convert.ToUInt32(value)-1;

            var actual = u.ChooseFieldType(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("4")]
        [TestCase("-1")]
        public void ChooseFieldType_inputMoreorLessThanExpected_ThrowException(string value)
        {
            Assert.Throws<InvalidInputException>(() => u.ChooseFieldType(value));
        }

        [TestCase("a")]
        [TestCase("\n")]
        public void ChooseFieldType_inputnotDigitString_ThrowException(string value)
        {
            Assert.Throws<InvalidInputException>(() => u.ChooseFieldType(value));
        }  
        
        [TestCase(" ")]
        public void ChooseFieldType_inputStringSpace_ThrowException(string value)
        {
            Assert.Throws<FormatException>(() => u.ChooseFieldType(value));
        }
        [Test]
        public void ChooseFieldSize_StringWandL_UintMassReturn()
        {
            var w = "4";
            var l = "5";
            uint[] expected = new uint[2] { 4, 5 };

            var actual = u.ChooseFieldSize(w, l);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new object[] {"a", "4" })]
        [TestCase(new object[] { "4", "a" })]
        [TestCase(new object[] { "\n", "4" })]
        [TestCase(new object[] { "4", "\n" })]
        public void ChooseFieldSize_WandLNotString_ThrowException(string value1, string value2)
        {
            Assert.Throws<InvalidInputException>(() => u.ChooseFieldSize(value1, value2));
        }
        
        [TestCase("a1 a2")]
        public void ParseMove_inputString_returnFromToCoords(string value)
        {
            FromToCoords ft0 = new FromToCoords(0, 0, 0, 1);
            FromToCoords ft1 = u.ParseMove(value);

            Assert.AreEqual(ft0, ft1);
        }  
        
        [TestCase("a a2")]
        public void ParseMove_inputString_ThrowException(string value)
        {
            FromToCoords ft0 = new FromToCoords(0, 0, 0, 1);
            FromToCoords ft1 = u.ParseMove(value);

            Assert.AreEqual(ft0, ft1);
        }




    }
}