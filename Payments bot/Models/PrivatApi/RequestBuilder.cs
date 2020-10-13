using Payments_bot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payments_bot.Models.PrivatApi
{
    public static class RequestBuilder
    {
      
        public static string GetBalance(Merchant merchant)
        {
            string data = new XElement("data",
                new XElement("oper", "cmt"),
                new XElement("wait", "0"),
                new XElement("test", "0"),
                new XElement("payment",
                new XAttribute("id", ""),
                new XElement("prop",
                new XAttribute("name", "cardnum"),
                new XAttribute("value", $"{merchant.SelectedCard}")),
                new XElement("prop",
                new XAttribute("name", "country"),
                new XAttribute("value", "UA")))
                ).ToString(SaveOptions.DisableFormatting);
           
            return GetBody(merchant,data);
        }
        public static string GetHistory(Merchant merchant,DateTime startDate , DateTime endDate)
        {
            string data = new XElement("data",
                  new XElement("oper", "cmt"),
                  new XElement("wait", "0"),
                  new XElement("test", "0"),
                  new XElement("payment",
                  new XAttribute("id", ""),
                  new XElement("prop",
                  new XAttribute("name", "sd"),
                  new XAttribute("value", $"{startDate}")),
                  new XElement("prop",
                  new XAttribute("name", "ed"),
                  new XAttribute("value", $"{endDate}")),
                  new XElement("prop",
                  new XAttribute("name", "card"),
                  new XAttribute("value", "{merchant.SelectedCard}")))

                  ).ToString(SaveOptions.DisableFormatting);
            
            return GetBody(merchant,data);
        }
        
        private static string GetBody(Merchant merchant , string data)
        {
            //класс XDeclaration некорректно добавляет декларацию в XDoc , дописал обычной строкой
            string declaration = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>";
            string head = new XDocument(

               new XElement("request",
               new XAttribute("version", "1.0"),
               new XElement("merchant",
               new XElement("id", merchant.Id),
               new XElement("signature", GetSignature(merchant, data))
               )
               )).ToString(SaveOptions.DisableFormatting);

            string request = declaration + head + data;
            
            return request;
        }
        private static string GetSignature(Merchant merchant, string data)
        {
            //метод для генерации сигнатуры необходимой для верификации запроса в privat24 API (https://api.privatbank.ua/#p24/balance)
            var sha1 = SHA1.Create();
            var md5 = MD5.Create();
            string key = data + merchant.Password;
            byte[] keybytes = Encoding.UTF8.GetBytes(key);
            string md5_key = md5.ComputeHash(keybytes).Select(x => x.ToString("x2")).Aggregate("", (x, y) => x + y);
            byte[] md5_keybytes = Encoding.UTF8.GetBytes(md5_key);
            string result = sha1.ComputeHash(md5_keybytes).Select(x => x.ToString("x2")).Aggregate("", (x, y) => x + y);
            return result;

        }

       
    }
}
