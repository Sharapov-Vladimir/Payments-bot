using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Models.PrivatApi.Responses
{
    public class HistoryResponse
    {
        public string Status { get; set; }
        public double Credit { get; set; }
        public double Debet { get; set; }
        public List<Statement> HistoryStatements { get; set; }
    }
}
