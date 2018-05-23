using BLDal.DomainModel;
using BLDal.Repository;
using BLDal.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLDal
{
    public class Facade
    {
        private IRepository<Booking> bookingRepo;
        private IRepository<Package> packageRepo;
        private IRepository<Extra> extraRepo;

        public IRepository<Booking> GetBookingRepository()
        {
            if(bookingRepo == null)
            {
                bookingRepo = new BookingRepository();
            }
            return bookingRepo;
        }

        public IRepository<Package> GetPackageRepository()
        {
            if(packageRepo == null)
            {
                packageRepo = new PackageRepository();
            }
            return packageRepo;
        }

        public IRepository<Extra> GetExtraRepository()
        {
            if(extraRepo == null)
            {
                extraRepo = new ExtraRepository();
            }
            return extraRepo;
        }

    }
}
