using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;

namespace TagsAppTests
{
    [TestFixture]
    class FieldTests
    {
        Field actual;
        FromToCoords fromto;

        [SetUp]
        public void SetUp()
        {
            actual = new Field(4, 4);
            actual.Tags[0, 0].Name = Tag.Empty;
        }

        [Test]
        public void MoveTag_AcceptFromToCoords_ReturnExchangedTags()
        {
            //arange
            var expected = new Field(4,4);
            expected.Tags[1, 0].Name = Tag.Empty;
            expected.Tags[0, 0].Name = "5";

            fromto = new FromToCoords(0, 0, 1, 0);

            //act 
            actual.MoveTag(fromto);

            //assert
            Assert.AreEqual(expected.Tags[0,0].Name, actual.Tags[0, 0].Name);
        }

        [TestCase(7, 6, 0, 1)]//no empty tag
        [TestCase(0, 0, 1, 1)]//too far
        [TestCase(0, 0, 0, 0)]//same tag
        [TestCase(-1, 0, 0, 0)]//out of the field
        public void MoveTag_InputWrongCoords_ThrowInvalidOperationException(
                                                                int fx, int fy, int tx, int ty)
        {
            //arrange
            fromto = new FromToCoords((uint)fx, (uint)fy, (uint)tx, (uint)ty);

            //assert
            Assert.Throws<InvalidOperationException>(() => actual.MoveTag(fromto));
        }
    }
}
