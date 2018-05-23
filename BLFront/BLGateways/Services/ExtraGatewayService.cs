using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLGateways.Services
{
    public class ExtraGatewayService
    {
        public IEnumerable<Extra> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4288/api/extra/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Extra>>().Result;

            }
        }

        public Extra Add(Extra extra)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4288/api/extra/", extra).Result;
                return response.Content.ReadAsAsync<Extra>().Result;
            }
        }

        public Extra Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4288/api/extra/" + id).Result;
                return response.Content.ReadAsAsync<Extra>().Result;
            }
        }

        public void Delete(Extra extra)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:4288/api/extra/" + extra.Id).Result;

            }
        }
        public Extra Update(Extra extra)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:4288/api/extra/" + extra.Id, extra).Result;
                return response.Content.ReadAsAsync<Extra>().Result;
            }

        }
    }
}
