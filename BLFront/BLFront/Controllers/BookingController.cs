using BLFront.Models.ViewModel;
using BLGateways;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Payment()
        {
            return View();
        }

    }
}