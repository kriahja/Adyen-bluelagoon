using BLDal;
using BLDal.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BlueLagoonRest.Controllers
{
    public class ExtraController : ApiController
    {
        // GET: Extra
        private Facade facade = new Facade();

        public IEnumerable<Extra> GetExtras()
        {
            return facade.GetExtraRepository().ReadAll();
        }

        public Extra GetExtra(int id)
        {
            return facade.GetExtraRepository().Find(id);
        }

        public void PostExtra(Extra Extra)
        {
            facade.GetExtraRepository().Add(Extra);
        }

        public void DeleteExtra(int id)
        {
            Extra Extra = facade.GetExtraRepository().Find(id);
            if (Extra == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.GetExtraRepository().Delete(id);
        }

        public void PutExtra(int id, Extra Extra)
        {
            Extra.Id = id;
            facade.GetExtraRepository().Edit(Extra);
        }
    }
}