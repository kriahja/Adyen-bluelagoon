using BLDal.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLDal.Context
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<BLContext>
    {

        protected override void Seed(BLContext context)
        {
            IList<Booking> bookings = new List<Booking>();

            Package pack1 = context.Packages.Add(new Package() { Id = 0, name = "Basic", price = 1000 });
            Package pack2 = context.Packages.Add(new Package() { Id = 0, name = "Deluxe", price = 3000 });

            bookings.Add(new Booking()
            {
                adult = 2,
                child = 0,
                date = new DateTime(2018,6,1),
                time = 1100,
                first = "John",
                last = "Johnson",
                email = "johnny@gg.com",
                mobil = "45592623",
                price = 1230

            });
            base.Seed(context);
        }
    }
}
