using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;

namespace TagsAppTests
{
    [TestFixture]
    class FieldMementoTests
    {
        [Test]
        public void Restore_AcceptW_L_Tags_ReturnFieldWithSameParameters()
        {
            //arrange
            var f = new Field(3, 3);
            f.Width = 3;
            f.Length = 3;
            f.Tags[0, 0].Name = Tag.Empty;

            var fieldMemento = new FieldMemento(f, f.Tags, f.Width, f.Length);

            fieldMemento.Tags[0, 1].Name = Tag.Empty;
            //act
            fieldMemento.Restore();
            //assert
            Assert.AreEqual(f.Tags[0,1].Name, fieldMemento.Tags[0,1].Name);
        }
    }
}
