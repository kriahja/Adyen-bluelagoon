using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLGateways.Services
{
    public class PaymentGatewayService
    {
        public HttpResponseMessage GetPaymentSession()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4288/api/payment/").Result;
                return response;

            }
        }
    }
}
