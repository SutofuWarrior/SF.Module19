using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF.Module19
{
    public class BotWorker
    {
        private ITelegramBotClient bot;
        private BotMessageLogic logic;

        public BotWorker Initialize()
        {
            bot = new TelegramBotClient(BotCredentials.BotToken);
            logic = new BotMessageLogic(bot);
            return this;
        }

        public BotWorker Start()
        {
            bot.OnMessage += Bot_OnMessage;
            //bot.OnCallbackQuery += Bot_OnCallbackQuery;
            bot.StartReceiving();
            return this;
        }

        //private async void Bot_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        //{
        //    var text = "";

        //    switch (e.CallbackQuery.Data)
        //    {
        //        case "pushkin":
        //            text = @"Я помню чудное мгновенье:
        //                            Передо мной явилась ты,
        //                            Как мимолетное виденье,
        //                            Как гений чистой красоты.";
        //            break;
        //        case "esenin":
        //            text = @"Не каждый умеет петь,
        //                        Не каждому дано яблоком
        //                        Падать к чужим ногам.";
        //            break;
        //        default:
        //            break;
        //    }

        //    await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, text);
        //    await bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        //}

        private async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message != null)
                await logic.Response(e);
        }

        public void Stop() => bot.StopReceiving();
    }
}
