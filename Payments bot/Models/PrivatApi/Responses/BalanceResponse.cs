using System.Globalization;
using System.Xml.Linq;

namespace Payments_bot.Models.PrivatApi.Responses
{
    public class BalanceResponse
    {

        public double AvailableBalance { get; set; } 
        public double Balance { get; set; }
        public double Limit { get; set; }
        public string UpdateTime { get; set; } 
        public string ErrorMes { get; set; }



        public BalanceResponse Build(string response)
        {
                var doc = XDocument.Parse(response);
                var data = doc?.Root?.Element("data")?.Element("info")?.Element("cardbalance");
                var errorElement = doc?.Root?.Element("data")?.Element("error");
                AvailableBalance =
                    double.Parse(data?.Element("av_balance")?.Value ?? "0", CultureInfo.InvariantCulture);
                Balance =
                    double.Parse(data?.Element("balance")?.Value ?? "0", CultureInfo.InvariantCulture);
                Limit =
                    double.Parse(data?.Element("fin_limit")?.Value ?? "0", CultureInfo.InvariantCulture);
                UpdateTime =
                     data?.Element("bal_date")?.Value ?? " " ;
            ErrorMes = 
                    (errorElement?.Attribute("message")?.Value)??" ";
                
            return this; 

        }
    }
}
