using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF.Module19
{
    public class BotMessageLogic
    {
        private readonly Messenger messanger;
        private readonly Dictionary<long, Conversation> chatList;
        private readonly ITelegramBotClient bot;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            bot = botClient;
            messanger = new Messenger(bot);
            chatList = new Dictionary<long, Conversation>();
        }

        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(Id))
                chatList.Add(Id, new Conversation(e.Message.Chat));

            var chat = chatList[Id];
            chat.AddMessage(e.Message);

            await messanger.MakeAnswer(chat);
        }
    }
}
