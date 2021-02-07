namespace SF.Module19
{
    public abstract class AbstractCommand : IChatCommand
    {
        public string CommandText;

        public bool CheckMessage(string message) 
            => CommandText == message;
    }
}
