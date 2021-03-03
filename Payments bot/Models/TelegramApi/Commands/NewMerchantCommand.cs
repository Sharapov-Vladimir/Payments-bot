using Payments_bot.Services;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi.Commands
{
    public class NewMerchantCommand:ITelegramCommand
    {
        public string Name { get; set; } = "/add";
        


        public ResponseTextMessage Execute(Message message)
        {

            
            return new ResponseTextMessage
            {
                //ссылка для создания нового мерчанта
                ChatId = message.Chat.Id,
                text = AppConfig.AppUrl + "/Home/NewMerchant/" + message.From.Id,
                keyboardMarkup = null

            };
        }
    }
}
