using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLGateways.Services
{
    public class BookingGatewayService
    {
        public IEnumerable<Booking> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4288/api/booking/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Booking>>().Result;

            }
        }

        public Booking Add(Booking booking)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4288/api/booking/", booking).Result;
                return response.Content.ReadAsAsync<Booking>().Result;
            }
        }

        public Booking Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4288/api/booking/" + id).Result;
                return response.Content.ReadAsAsync<Booking>().Result;
            }
        }

        public void Delete(Booking booking)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:4288/api/booking/" + booking.Id).Result;

            }
        }
        public Booking Update(Booking booking)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:4288/api/booking/" + booking.Id, booking).Result;
                return response.Content.ReadAsAsync<Booking>().Result;
            }

        }
    }
}
