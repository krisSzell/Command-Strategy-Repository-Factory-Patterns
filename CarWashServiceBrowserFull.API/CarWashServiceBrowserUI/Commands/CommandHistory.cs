using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarWashServiceBrowserFull.API.Models;

namespace CarWashServiceBrowserUI.Commands
{
    public class CommandHistory
    {
        private Stack<IServiceOperationCommand> _commands = new Stack<IServiceOperationCommand>();

        public void Execute(IServiceOperationCommand command)
        {
            command.Execute();
            _commands.Push(command);
        }

        public Service Undo()
        {
            if (_commands.Count > 0)
            {
                var command = _commands.Pop();
                return command.Undo();
            }
            return null;
        }

        public IServiceOperationCommand GetLastCommand()
        {
            if (_commands.Count > 0)
            {
                return _commands.First();
            }
            // should put default command here
            return null;
        }
    }
}
