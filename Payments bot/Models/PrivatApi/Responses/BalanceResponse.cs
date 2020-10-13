using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Models.PrivatApi.Responses
{
    public class BalanceResponse
    {
        public string Account { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public string Currency { get; set; }
        public string CardStat { get; set; }
        public double FinLimit { get; set; }
        public double AvailableBalance { get; set; }
        public double Balance { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
