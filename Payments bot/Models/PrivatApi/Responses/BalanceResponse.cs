
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payments_bot.Models.PrivatApi.Responses
{
    public class BalanceResponse:IResponse
    {
       
        public double AvailableBalance { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public DateTime UpdateTime { get; set; }



        public  IResponse Build(string response)
        {
            XDocument doc = XDocument.Parse(response);
            this.AvailableBalance = 
                double.Parse(doc.Root.Element("av_balance").Value, CultureInfo.InvariantCulture);
            this.Balance = 
                double.Parse(doc.Root.Element("balance").Value , CultureInfo.InvariantCulture);
            this.Limit = 
                double.Parse(doc.Root.Element("fin_limit").Value , CultureInfo.InvariantCulture);
            this.UpdateTime = 
                DateTime.ParseExact(doc.Root.Element("bal_date").Value, "dd.MM.yy HH:mm", CultureInfo.InvariantCulture);
            return this;
        }
    }
}
