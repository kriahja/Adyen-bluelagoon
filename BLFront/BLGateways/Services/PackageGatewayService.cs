using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLGateways.Services
{
    public class PackageGatewayService
    {
        public IEnumerable<Package> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4288/api/package/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Package>>().Result;

            }
        }

        public Package Add(Package package)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4288/api/package/", package).Result;
                return response.Content.ReadAsAsync<Package>().Result;
            }
        }

        public Package Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4288/api/package/" + id).Result;
                return response.Content.ReadAsAsync<Package>().Result;
            }
        }

        public void Delete(Package package)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:4288/api/package/" + package.Id).Result;

            }
        }
        public Package Update(Package package)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:4288/api/package/" + package.Id, package).Result;
                return response.Content.ReadAsAsync<Package>().Result;
            }

        }
    }
}
