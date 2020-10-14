using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Models.PrivatApi.Responses
{
   public interface IResponse
    {
        public IResponse Build(string response);
    }
}
