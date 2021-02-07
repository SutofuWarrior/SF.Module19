using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Module19
{
    public class Messenger
    {
        private readonly CommandParser commandParser = new CommandParser();
        private readonly ITelegramBotClient bot;

        public Messenger(ITelegramBotClient bot)
        {
            this.bot = bot;
        }

        public async Task MakeAnswer(Conversation chat)
        {
            var message = chat.GetLastMessage();
            var chatCommand = chat.CurrentCommand;

            if (chatCommand != null && !chatCommand.IsCompleate)
            {
                var text = chatCommand.HandleNextMessage(message);
                await bot.SendTextMessageAsync(chatId: chat.GetId(), text: text);
            }
            else if (commandParser.CheckCommandType<IChatTextCommand>(message))
            {
                var text = commandParser.GetCommand<IChatTextCommand>(message).ReturnText();
                await bot.SendTextMessageAsync(chatId: chat.GetId(), text: text);
            }
            //else if (commandParser.CheckCommandType<IChatButtonCommand>(message))
            //{
            //    var keyboard = commandParser.GetCommand<IChatButtonCommand>(message).ReturnKeyBoard();
            //    await bot.SendTextMessageAsync(chatId: chat.GetId(), text: "", replyMarkup: keyboard);
            //}
            else if (commandParser.CheckCommandType<IMultiStageCommand>(message))
            {
                chatCommand = (IMultiStageCommand)commandParser.GetCommand<IMultiStageCommand>(message).Clone();
                chat.CurrentCommand = chatCommand;
                var text = chatCommand.HandleNextMessage(message);
                await bot.SendTextMessageAsync(chatId: chat.GetId(), text: text);
            }
            else
                CreateTextMessage(chat);
        }

        public string CreateTextMessage(Conversation chat)
        {
            var delimiter = ",";
            return "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
        }
    }
}
