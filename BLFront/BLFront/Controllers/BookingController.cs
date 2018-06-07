using BLFront.Models;
using BLFront.Models.ViewModel;
using BLGateways;
using Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace BLFront.Controllers
{
    public class BookingController : Controller
    {
        private Facade facade = new Facade();
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Calendar()
        {
            var booking = new BookingViewModel()
            {
                Package = new SelectList(facade.GetPackageGateway().ReadAll(),"Id", "Name"),
                Extras = new MultiSelectList(facade.GetExtraGateway().ReadAll(), "Id", "Name")
            };
            return View(booking);
        }

        [HttpPost]
        public ActionResult Calendar([Bind(Include = "Booking, Package, selectedPack, Extras, selectedExtras")] BookingViewModel booking)
        {
            return RedirectToAction("Timetable", booking);
        }


        [HttpGet]
        public ActionResult Timetable(BookingViewModel booking)
        {
            return View(booking);
        }

        [HttpPost]
        [ActionName("Timetable")]
        public ActionResult TimetablePost([Bind(Include = "Booking, Package, selectedPack, Extras, selectedExtras")] BookingViewModel booking)
        {
            return RedirectToAction("Person", booking);
        }
        
        [HttpGet]
        public ActionResult Person(BookingViewModel booking)
        {
            return View(booking);
        }

        [HttpPost]
        [ActionName("Person")]
        public ActionResult PersonPost([Bind(Include = "Booking, Package, selectedPack, Extras, selectedExtras")] BookingViewModel booking)
        {
            List<Package> allPack = new List<Package>(facade.GetPackageGateway().ReadAll());
            for(int i = 0; i < allPack.Count; ++i)
            {
                if(allPack.ElementAt(i).Id == booking.selectedPack)
                {
                    booking.Booking.Package = allPack.ElementAt(i);
                }
            }

            if(booking.selectedExtras != null)
            {
                var newList = new List<Extra>();
                List<Extra> allExtra = new List<Extra>(facade.GetExtraGateway().ReadAll());
                for(int i = 0; i < allExtra.Count(); ++i)
                {
                    for(int j = 0; j < booking.selectedExtras.Count(); ++j)
                    {
                        if (allExtra.ElementAt(i).Id == booking.selectedExtras.ElementAt(j))
                            newList.Add(new Extra() { Id = booking.selectedExtras.ElementAt(j), name = allExtra.ElementAt(i).name });
                    }
                }
            }
            booking.Booking.price = 100;
            facade.GetBookingGateway().Add(booking.Booking);

            return RedirectToAction("Index");
        }

        public async System.Threading.Tasks.Task<ActionResult> Payment()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
            HttpResponseMessage p = facade.GetPaymentGateway().GetPaymentSession();
           
            string paymentSession = await p.Content.ReadAsStringAsync();

            var pay = JObject.Parse(paymentSession);
            var sess = pay["paymentSession"];
            ViewBag.Message = sess;
            
            return View();
        }

        public HttpResponseMessage Verify(string payLoad)
        {
            using (var client = new HttpClient())
            {
                Verify verify = new Verify();
                verify.payload = payLoad;

                MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
                HttpContent content = new ObjectContent<Verify>(verify, jsonFormatter);

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://checkout-test.adyen.com/v32/payments/result"),
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