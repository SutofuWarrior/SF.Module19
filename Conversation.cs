using System.Collections.Generic;
using Telegram.Bot.Types;

namespace SF.Module19
{
    public class Conversation
    {
        private readonly Chat telegramChat;
        private readonly List<Message> telegramMessages;
        private readonly IEnglishTrainer trainer;
        private IMultiStageCommand command;

        public IMultiStageCommand CurrentCommand 
        {
            get => command;
            set
            {
                command = value;

                if (command is ITrainerInteractor tr)
                    tr.Trainer = trainer;
            }
        }

        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
            trainer = new EnglishTrainer();
        }

        public void AddMessage(Message message) 
            => telegramMessages.Add(message);

        public List<string> GetTextMessages()
        {
            var textMessages = new List<string>();

            foreach (var message in telegramMessages)
                if (message.Text != null)
                    textMessages.Add(message.Text);

            return textMessages;
        }

        public long GetId() => telegramChat.Id;

        public string GetLastMessage() => telegramMessages[^1].Text;

    }
}
