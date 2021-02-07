namespace SF.Module19
{
    public class DeleeteWordCommand : AbstractCommand, IMultiStageCommand, ITrainerInteractor
    {
        private enum CommandState
        {
            Start,
            AskWord,
            Done
        }

        private CommandState _currentState;

        public DeleeteWordCommand()
        {
            CommandText = "/deleteword";
            _currentState = CommandState.Start;
        }

        public bool IsCompleate => _currentState == CommandState.Done;

        public IEnglishTrainer Trainer { get; set; }

        public string HandleNextMessage(string message)
        {
            string text = string.Empty;

            switch (_currentState)
            {
                case CommandState.Start:
                    text = "Введите английское слово, которое вы хотите удалить";
                    _currentState = CommandState.AskWord;
                    break;

                case CommandState.AskWord:
                    Trainer.DeleteWord(message);
                    text = $"Слово {message} удалено из словаря";
                    _currentState = CommandState.Done;
                    break;

                case CommandState.Done:
                default:
                    break;
            }

            return text;
        }

        public object Clone() => new DeleeteWordCommand();
    }
}
