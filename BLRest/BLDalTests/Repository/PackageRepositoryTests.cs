using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLDal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLDal.DomainModel;

namespace BLDal.Repository.Tests
{
    [TestClass()]
    public class PackageRepositoryTests
    {
        PackageRepository repo = new PackageRepository();

        Package pack1 = new Package() { Id = 1, name = "Basic", price = 1000 };
        Package pack2 = new Package() { Id = 2, name = "Deluxe", price = 3000 };


        public List<Package> Packages()
        {
            return repo.ReadAll();
        }

        public bool comparer(Package a, Package b)
        {
            if (a.name == b.name && a.Id == b.Id)
            {
                return true;
            }
            return false;
        }

        public bool listcomparer(List<Package> a, List<Package> b)
        {
            bool equals = true;
            if (a.Count() != b.Count())
            {
                return false;
            }
            else
            {
                for (int i = 0; i < a.Count(); ++i)
                {
                    if (!comparer(a[i], b[i]))
                    {
                        equals = false;
                    }
                }
            }
            return equals;
        }

        public List<Package> ExpectedPackages()
        {
            List<Package> expected = new List<Package>();
            expected.Add(pack1);
            expected.Add(pack2);
            return expected;
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            List<Package> expected = ExpectedPackages();

            List<Package> actual = Packages();
            
            Assert.IsTrue(listcomparer(expected, actual));
         
        }

        [TestMethod()]
        public void FindTest()
        {
            Package expected = new Package();
            List<Package> exPack = ExpectedPackages();
            foreach (var item in exPack)
            {
                if (item.Id == 1)
                {
                    expected = item;
                }

            }

            Package actual = repo.Find(1);

            Assert.IsTrue(comparer(expected, actual));

        }

        [TestMethod()]
        public void AddandDeleteTest()
        {
            List<Package> expected = ExpectedPackages();
            Package package = new Package() { Id = 3, name = "Cool" };

            expected.Add(package);
            repo.Add(package);
            List<Package> actual = repo.ReadAll();
            Package actuall = actual.Last();
            Assert.IsTrue(comparer(package, actuall));

            repo.Delete(package.Id);
            expected.Remove(package);

            Assert.IsTrue(listcomparer(repo.ReadAll(), expected));

        }

        [TestMethod()]
        public void EditTest()
        {
            Package package = repo.Find(1);
            package.name = "Updated";
            repo.Edit(package);
            Package actual = repo.Find(1);
            Assert.IsTrue(comparer(package, actual));
        }


    }
    
}
