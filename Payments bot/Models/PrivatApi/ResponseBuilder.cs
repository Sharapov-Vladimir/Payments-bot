using Payments_bot.Data;
using Payments_bot.Models.PrivatApi.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Payments_bot.Models.PrivatApi
{
    public static class ResponseBuilder
    {
        static CultureInfo culture = new CultureInfo("uk-UA");
        public static string GetBalance(Merchant merchant)
        {
            
            BalanceResponse response = Requester.GetBalanceResult(merchant).Result;
            string Av_Balance = response.AvailableBalance.ToString("C2", culture);
            string Limit = response.Limit.ToString("C2", culture);
           
            string balance = $"Баланс = {Av_Balance} 💰, " + Environment.NewLine +
                   $"кредитный лимит = {Limit} 💳, " + Environment.NewLine +
                   $"дата последней операции = {response.UpdateTime} 🏧"+Environment.NewLine+response.ErrorMes;

                return balance;
            
            
        }


        public  static string GetHistory(Merchant merchant , DateTime startdate , DateTime enddate)
        {
            HistoryResponse response = Requester.GetHistoryResult(merchant,startdate,enddate).Result;
            string debet = response.Debet.ToString("C2", culture);
            string credit = response.Credit.ToString("C2", culture);
            string statements = SortStatements(response.HistoryStatements);

            string history = $"Поступления = {credit} 💰 , траты = {debet} 💳" 
                + Environment.NewLine+statements+Environment.NewLine+response.ErrorMes;
            
            return history;
        }
        private static string SortStatements(List<Statement> data)
        {
            var statements = data;
            string info = "";
            double value = 0;
            Dictionary<string, double> categories = new Dictionary<string, double>
            {
                {"🍴 продукты = ", 0 },
                {"🎳 развлечения = " ,0},
                { "💰 платежи = ", 0},
                { "🚋 услуги туризма = ", 0},
                { "🧬 красота и здоровье = ", 0 },
                { "🛍 шопинг = ",0 },
                { "🍲 рестораны и бары = ",0 },
                { "💳 переводы = ",0 },
                { "💵 снятие наличных = ",0},
                { "📶 пополнение мобильного = ", 0 },
                { "🔨 товары для дома = ", 0},
                {"🛋 бытовая техника = " , 0},
                { "🚗 авто = ", 0},
                { "⛽ азс = " , 0 },
                { "🏧 банковские услуги = " , 0},
                { "🖥 интернет магазины = " , 0},
                { "🏡 коммунальные услуги = " , 0},
                { "🗄 другое = " , 0}
        };
            var list = categories.ToList();
           
            
            foreach(var statement in statements)
            {
                info = statement.Description.Split(" ")[0].Trim(':').ToLowerInvariant();
                value = statement.CardAmount;
                foreach(var pair in list)
                {
                    
                    if (pair.Key.Contains(info)&&value<0)
                    {
                        categories[pair.Key] = categories[pair.Key] + statement.Amount;
                        break;
                    }
                    if (pair.Key == list[list.Count - 1].Key&&value < 0)
                    {
                        categories[pair.Key] = categories[pair.Key] + statement.Amount;
                    }
                }
            }


            string result = string.Concat(
                categories.
                Where(pair=>pair.Value!=0).
                Aggregate("",(x,y)=>x+Environment.NewLine+y.Key+y.Value.ToString("C2", culture)));
            return result; 
        }

    }
}
