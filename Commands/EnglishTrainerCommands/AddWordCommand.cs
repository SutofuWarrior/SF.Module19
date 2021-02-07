using System;

namespace SF.Module19
{
    public class AddWordCommand : AbstractCommand, IMultiStageCommand, ITrainerInteractor
    {
        private enum CommandState
        {
            Start,
            AskRussianWord,
            AskEnglishWord,
            AskSubject,
            Done
        }

        private CommandState _currentState;
        private readonly Word _word;

        public AddWordCommand()
        {
            CommandText = "/addword";
            _currentState = CommandState.Start;
            _word = new Word();
        }

        public bool IsCompleate => _currentState == CommandState.Done;

        public IEnglishTrainer Trainer { get; set; }

        public string HandleNextMessage(string message)
        {
            string text = string.Empty;

            switch (_currentState)
            {
                case CommandState.Start:
                    text = "Введите русское значение слова";
                    _currentState = CommandState.AskRussianWord;
                    break;

                case CommandState.AskRussianWord:
                    _word.RussianWord = message;
                    text = "Введите английское значение слова";
                    _currentState = CommandState.AskEnglishWord;
                    break;

                case CommandState.AskEnglishWord:
                    _word.EnglishWord = message;
                    text = "Введите тематику";
                    _currentState = CommandState.AskSubject;
                    break;

                case CommandState.AskSubject:
                    _word.Subject = message;
                    Trainer.AddWord(_word);
                    text = $"Успешно! Слово {_word.EnglishWord} добавлено в словарь";
                    _currentState = CommandState.Done;
                    break;

                case CommandState.Done:
                default:
                    break;
            }

            return text;
        }

        public object Clone() => new AddWordCommand();
    }
}
