using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Module19
{
    public interface IChatCommand
    {
        bool CheckMessage(string message);
    }

    public interface IChatTextCommand
    {
        string ReturnText();
    }

    public interface IChatButtonCommand
    {
        InlineKeyboardMarkup ReturnKeyBoard();
    }

    public interface IMultiStageCommand : ICloneable
    {
        bool IsCompleate { get; }

        string HandleNextMessage(string message);
    }

    public interface ITrainerInteractor
    {
        public IEnglishTrainer Trainer { get; set; }
    }
}
