using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payments_bot.Models.PrivatApi.Responses
{
    public class HistoryResponse
    {
        
        public double Credit { get; set; }
        public double Debet { get; set; }
        public List<Statement> HistoryStatements { get; set; }

        public HistoryResponse Build(string response)
        {
            XDocument doc = XDocument.Parse(response);
            IEnumerable<XElement> statements = doc.Elements("statement");
            HistoryStatements = new List<Statement>();

            this.Credit = 
                double.Parse(doc.Root.Element("statements").Attribute("credit").Value, CultureInfo.InvariantCulture);
            this.Debet =
                double.Parse(doc.Root.Element("statements").Attribute("debet").Value, CultureInfo.InvariantCulture);

            foreach (var statement in statements)
            {
                HistoryStatements.Add(new Statement
                {
                    Amount = statement.Attribute("amount").Value,
                    CardAmount = statement.Attribute("cardamount").Value,
                    Description = statement.Attribute("description").Value,
                    Rest = statement.Attribute("rest").Value,

                    TransactionDate =
                            DateTime.ParseExact(statement.Attribute("trandate").Value, "yyyy-MM-dd",
                                CultureInfo.InvariantCulture)
                });
            }



            return this;
        }
    }
}
