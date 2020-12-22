using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;
using TagsApp.Command;
using TagsApp.Meemento;

namespace TagsAppTests
{
    [TestFixture]
    class UndoCommandTests
    {
        Mock<ICommand> mockUndoCommand;
        [Test]
        public void Execute_MoveTagResult()
        {
            mockUndoCommand = new Mock<ICommand>();
            mockUndoCommand.Setup(undo => undo.Execute()).Verifiable();
            ICommand command = mockUndoCommand.Object;
            //act
            command.Execute();
            //assert
            mockUndoCommand.Verify(move => move.Execute());
        }
    }
}
