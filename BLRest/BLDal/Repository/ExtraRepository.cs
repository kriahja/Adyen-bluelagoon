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
    public class ExtraRepository : IRepository<Extra>
    {
        private List<Extra> Extras = new List<Extra>();

        public void Add(Extra Extra)
        {
            using (var ctx = new BLContext())
            {
                ctx.Extras.Add(Extra);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Extra Extra = Find(id);
            using (var ctx = new BLContext())
            {
                ctx.Extras.Attach(Extra);
                ctx.Extras.Remove(Extra);
                ctx.SaveChanges();
            }
        }

        public void Edit(Extra Extra)
        {
            using (var ctx = new BLContext())
            {
                var ExtraDB = ctx.Extras.FirstOrDefault(x => x.Id == Extra.Id);
                ctx.Entry(ExtraDB).CurrentValues.SetValues(Extra);
              
                ctx.SaveChanges();

            }
        }

        public Extra Find(int id)
        {
            foreach (var item in ReadAll())
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Extra> ReadAll()
        {
            using (var ctx = new BLContext())
            {
                return ctx.Extras.ToList();
            }
        }
    }
}
