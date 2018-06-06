using BLDal;
using BLDal.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BlueLagoonRest.Controllers
{
    public class BookingController : ApiController
    {
        private Facade facade = new Facade();

        public IEnumerable<Booking> GetBookings()
        {
            return facade.GetBookingRepository().ReadAll();
        }

        public Booking GetBooking(int id)
        {
            return facade.GetBookingRepository().Find(id);
        }

        public void PostBooking(Booking booking)
        {

            


            facade.GetBookingRepository().Add(booking);
        }

       

        public void DeleteBooking(int id)
        {
            Booking booking = facade.GetBookingRepository().Find(id);
            if (booking == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.GetBookingRepository().Delete(id);
        }

        public void PutBooking(int id, Booking booking)
        {
            booking.Id = id;
            facade.GetBookingRepository().Edit(booking);
        }
    }
}