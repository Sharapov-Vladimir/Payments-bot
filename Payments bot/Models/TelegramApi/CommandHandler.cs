using Payments_bot.Data;
using Payments_bot.Models.TelegramApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi
{
    public static class CommandHandler
    {
        public static ResponseTextMessage Handle(BotContext context, Message message)
        {
            ResponseTextMessage response = null;
            
            List<ITelegramCommand> commands = new List<ITelegramCommand>
             {
                 new MyMerchantsCommand(context),
                 new DeleteMerchantCommand(context),
                 new NewMerchantCommand()

             };
            
            try
            {
                var command = commands.First(c => c.Name == message.Text.ToLowerInvariant());
                
                response = command.Execute(message);

                return response;
            }
            catch (Exception)
            {
                //игнорирует сообщения несоответствующие формату команд /command
                return response;
            }

        }


    }
    }

