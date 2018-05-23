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
    public class PackageController : ApiController
    {
        private Facade facade = new Facade();
        public IEnumerable<Package> GetPackages()
        {
            return facade.GetPackageRepository().ReadAll();
        }


        public void PostPackage(Package Package)
        {
            facade.GetPackageRepository().Add(Package);

        }

        public void DeletePackage(int id)
        {
            Package Package = facade.GetPackageRepository().Find(id);
            if (Package == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.GetPackageRepository().Delete(id);
        }

        public void PutPackage(int id, Package Package)
        {
            Package.Id = id;
            facade.GetPackageRepository().Edit(Package);
        }
    }
}