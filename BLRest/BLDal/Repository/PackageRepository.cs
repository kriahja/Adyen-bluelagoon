using BLDal.Context;
using BLDal.DomainModel;
using BLDal.Repository;
using BLDal.Repository.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLDal.Repository
{
    public class PackageRepository : IRepository<Package>
    {

        private List<Package> packages = new List<Package>();
        public void Add(Package package)
        {
            using (var ctx = new BLContext())
            {
                ctx.Packages.Attach(package);
                ctx.Packages.Add(package);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Package package = Find(id);
            using (var ctx = new BLContext())
            {
                ctx.Packages.Attach(package);
                ctx.Packages.Remove(package);
                ctx.SaveChanges();
            }
        }

        public void Edit(Package package)
        {
            using (var ctx = new BLContext())
            {
                var packageDB = ctx.Packages.FirstOrDefault(x => x.Id == package.Id);
                packageDB.name = package.name;
                packageDB.price = package.price;
                ctx.SaveChanges();
            }
        }

        public Package Find(int id)
        {
            foreach(var item in ReadAll())
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Package> ReadAll()
        {
            using (var ctx = new BLContext())
            {
                return ctx.Packages.ToList();
            }
        }
    }
}

   