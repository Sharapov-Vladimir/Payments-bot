using Payments_bot.Models.TelegramApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi
{
    public static class CommandHandler
    {

             private static List<ICommand> commands = new List<ICommand>
             {


             };

        public static void Handle(TelegramBotClient client, Message message)
        {


            try
            {
                var command = commands.First(c => c.Name == message.Text.ToLowerInvariant());
                command.Execute(client, message);
            }
            catch (Exception e)
            {
                client.SendTextMessageAsync(chatId: message.Chat, text: e.Message);
            }

        }


    }
    }

