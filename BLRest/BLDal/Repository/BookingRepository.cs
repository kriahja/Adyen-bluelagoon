using BLDal.Context;
using BLDal.DomainModel;
using BLDal.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLDal.Repository
{
    public class BookingRepository : IRepository<Booking>
    {
        private List<Booking> bookings = new List<Booking>();

        public void Add(Booking booking)
        {
            using (var ctx = new BLContext())
            {
                ctx.Bookings.Add(booking);
                ctx.Entry(booking.Package).State = System.Data.Entity.EntityState.Unchanged;
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Booking booking = Find(id);
            using (var ctx = new BLContext())
            {
                ctx.Bookings.Attach(booking);
                ctx.Bookings.Remove(booking);
                ctx.SaveChanges();
            }
        }

        public void Edit(Booking booking)
        {
            using (var ctx = new BLContext())
            {
                var bookingDB = ctx.Bookings.Include("Package").FirstOrDefault(x => x.Id == booking.Id);
                ctx.Entry(bookingDB).CurrentValues.SetValues(booking);
                if(bookingDB.Package.Id != booking.Package.Id)
                {
                    bookingDB.Package = booking.Package;
                    ctx.Entry(booking.Package).State = EntityState.Unchanged;
                }
                ctx.SaveChanges();

            }
        }

        public Booking Find(int id)
        {
            foreach (var item in ReadAll())
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Booking> ReadAll()
        {
            using (var ctx = new BLContext())
            {
                return ctx.Bookings.Include("Package").ToList();
            }
        }
    }
}
