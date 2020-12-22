using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Meemento;

namespace TagsApp.Command
{
    public class UndoCommand : ICommand
    {
        private HistoryCareTaker history;

        public UndoCommand(HistoryCareTaker _history)
        {
            history = _history;
        }

        public void Execute()
        {            
            history.Undo();
        }
    }
}
