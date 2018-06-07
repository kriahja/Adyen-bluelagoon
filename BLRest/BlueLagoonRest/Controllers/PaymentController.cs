using BLDal.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BlueLagoonRest.Controllers
{
    public class PaymentController : ApiController
    {
        public HttpResponseMessage GetPayment()
        {

            using (var client = new HttpClient())
            {
                Payment p = new Payment();

                
                p.reference = "Your order number";
                p.merchantAccount = "BlueLagoonIS";
                p.sdkVersion = "1.3.0";
                p.shopperReference = "yourShopperId_IOfW3k9G2PvXFu2j";
                p.channel = "web";
                p.html = true;
                p.origin = "http://localhost:2739/Booking/Payment";
                p.returnUrl = "https://www.google.com";
                p.countryCode = "NL";
                p.shopperLocale = "nl_NL";
                p.amount = new Amount();
                p.amount.currency = "EUR";
                p.amount.value = "17408";

                //  client.DefaultRequestHeaders.Add("X-API-Key", "AQEohmfuXNWTK0Qc+iSSnnE9i+WcR4RDXcAbzbFpDx9OO+rHAwM5jxbGqxDBXVsNvuR83LVYjEgiTGAH-DUrUf5Wg6L0BVVYghEtoDaKMpVcVH++sBykcQv5GQFE=-pcey6tpM7uxSMry7");

                //  var response = client.PostAsJsonAsync("https://checkout-test.adyen.com/v32/paymentSession", p).Result;

                MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
                HttpContent content = new ObjectContent<Payment>(p, jsonFormatter);
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://checkout-test.adyen.com/v32/paymentSession"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                request.Headers.Add("X-API-Key", "AQEohmfuXNWTK0Qc+iSSnnE9i+WcR4RDXcAbzbFpDx9OO+rHAwM5jxbGqxDBXVsNvuR83LVYjEgiTGAH-DUrUf5Wg6L0BVVYghEtoDaKMpVcVH++sBykcQv5GQFE=-pcey6tpM7uxSMry7");

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var response = client.SendAsync(request).Result;
                return response;

            }
        }
    }
}
 