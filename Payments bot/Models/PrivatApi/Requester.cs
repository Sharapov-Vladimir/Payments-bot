using Payments_bot.Data;
using Payments_bot.Models.PrivatApi.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments_bot.Models.PrivatApi
{
    public static class Requester
    {
        
      public static async Task<BalanceResponse> GetBalanceResult(Merchant merchant)
        {
            string Url = @"https://api.privatbank.ua/p24api/balance";
            string request = RequestBuilder.GetBalance(merchant);
            HttpContent content = new StringContent(request);
            BalanceResponse balanceResponse = new BalanceResponse();
            using (var client = new HttpClient())
            {
                var result = await client.PostAsync(Url, content);
               
                if (!result.IsSuccessStatusCode)
                    return new BalanceResponse
                    {
                        AvailableBalance = 0,
                        Balance = 0,
                        Limit = 0,
                        UpdateTime = "",
                        ErrorMes = "Requester Error"
                    }; 
                
                using (result)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    return balanceResponse.Build(response);
                }
            }

        }
        public static async Task<HistoryResponse> GetHistoryResult(Merchant merchant , DateTime startdate , DateTime enddate)
        {
            string Url = @"https://api.privatbank.ua/p24api/rest_fiz";
            string request = RequestBuilder.GetHistory(merchant,startdate,enddate);
            HttpContent content = new StringContent(request);
            HistoryResponse historyResponse = new HistoryResponse();
            using (var client = new HttpClient())
            {
                var result = await client.PostAsync(Url, content);

                if (!result.IsSuccessStatusCode)
                    return new HistoryResponse
                    {
                        Credit = 0,
                        Debet=0,
                        HistoryStatements=new List<Statement>(),
                        ErrorMes = "Requester Error"
                    }; 

                using (result)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    return historyResponse.Build(response);
                }
            }

        }
     



    }
}
