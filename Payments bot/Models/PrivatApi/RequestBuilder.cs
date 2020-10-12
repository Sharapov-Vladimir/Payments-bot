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
    public class RequestBuilder
    {
        public static string Build(Merchant merchant, XElement data)
        {

            XDocument xdoc = new XDocument(

                new XElement("request",
                new XAttribute("version", "1.0"),
                new XElement("merchant",
                new XElement("id", merchant.Id),
                new XElement("signature", GetSignature(merchant, data)),
                data)
                ));




            return xdoc.ToString();
        }
        private static string GetSignature(Merchant merchant, XElement data)
        {
            //метод для генерации сигнатуры необходимой для верификации запроса в privat24 API (https://api.privatbank.ua/#p24/balance)
            var sha1 = SHA1.Create();
            var md5 = MD5.Create();
            string key = data.ToString(SaveOptions.DisableFormatting) + merchant.Password;
            byte[] keybytes = Encoding.UTF8.GetBytes(key);
            string md5_key = md5.ComputeHash(keybytes).Select(x => x.ToString("x2")).Aggregate("", (x, y) => x + y);
            byte[] md5_keybytes = Encoding.UTF8.GetBytes(md5_key);
            string result = sha1.ComputeHash(md5_keybytes).Select(x => x.ToString("x2")).Aggregate("", (x, y) => x + y);
            return result;

        }
    }
}
