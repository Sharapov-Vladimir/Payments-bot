using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Payments_bot.Models.PrivatApi.Responses
{
    public class HistoryResponse
    {
        
        public double Credit { get; set; }
        public double Debet { get; set; }
        public string ErrorMes { get; set; }
        public List<Statement> HistoryStatements { get; set; }
        

        public HistoryResponse Build(string response)
        {
            var doc = XDocument.Parse(response);
            var errorElement = doc?.Root?.Element("data")?.Element("error");
            var info = doc?.Root?.Element("data")?.Element("info");
            var statements =info?.Element("statements")?.XPathSelectElements("statement");


                HistoryStatements = new List<Statement>();
            ErrorMes =
               (errorElement?.Attribute("message")?.Value) ?? " ";

                Credit =
                    double.Parse(info?.Element("statements")?.Attribute("credit")?.Value ?? "0",CultureInfo.InvariantCulture);
                Debet =
                    double.Parse(info?.Element("statements")?.Attribute("debet")?.Value ?? "0", CultureInfo.InvariantCulture);

            if (statements != null)
            {
                foreach (var statement in statements)
                {
                    HistoryStatements.Add(new Statement
                    {
                        Amount =
                        double.Parse(statement?.Attribute("amount")?.Value.Split(" ")[0].Replace('.', ','), new CultureInfo("uk-UA")),
                        CardAmount =
                        double.Parse(statement?.Attribute("cardamount")?.Value.Split(" ")[0].Replace('.', ',')),
                        Description =
                        statement?.Attribute("description")?.Value,
                        Rest =
                        double.Parse(statement?.Attribute("rest")?.Value.Split(" ")[0].Replace('.', ',')),

                        TransactionDate =
                                DateTime.ParseExact(statement?.Attribute("trandate")?.Value, "yyyy-MM-dd",
                                    CultureInfo.InvariantCulture)
                    });
                }
            }
            
            return this;
            
        }
    }
}
