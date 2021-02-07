using System.Collections.Generic;

namespace SF.Module19
{
    public class CommandParser
    {
        private readonly List<IChatCommand> Command;

        public CommandParser()
        {
            Command = new List<IChatCommand>
            {
                new AddWordCommand(),
                new DeleeteWordCommand()
            };
        }

        public bool CheckCommandType<T>(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));
            return command is T;
        }

        public T GetCommand<T>(string message) 
            => (T)Command.Find(x => x.CheckMessage(message));
    }
}
