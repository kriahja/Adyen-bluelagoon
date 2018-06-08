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
    public class ExtraRepositoryTests
    {
        ExtraRepository repo = new ExtraRepository();

        Extra ext1 = new Extra() { Id = 1, name = "Reservation", price = 0 };
        Extra ext2 = new Extra() { Id = 2, name = "Massage", price = 500 };



        public List<Extra> Extras()
        {
            return repo.ReadAll();
        }

        public bool comparer(Extra a, Extra b)
        {
            if (a.name == b.name && a.Id == b.Id)
            {
                return true;
            }
            return false;
        }

        public bool listcomparer(List<Extra> a, List<Extra> b)
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

        public List<Extra> ExpectedExtras()
        {
            List<Extra> expected = new List<Extra>();
            expected.Add(ext1);
            expected.Add(ext2);
            return expected;
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            List<Extra> expected = ExpectedExtras();

            List<Extra> actual = Extras();

            Assert.IsTrue(listcomparer(expected, actual));

        }

        [TestMethod()]
        public void FindTest()
        {
            Extra expected = new Extra();
            List<Extra> exPack = ExpectedExtras();
            foreach (var item in exPack)
            {
                if (item.Id == 1)
                {
                    expected = item;
                }

            }

            Extra actual = repo.Find(1);

            Assert.IsTrue(comparer(expected, actual));

        }

        [TestMethod()]
        public void AddandDeleteTest()
        {
            List<Extra> expected = ExpectedExtras();
            Extra extage = new Extra() { Id = 3, name = "Cool" };

            expected.Add(extage);
            repo.Add(extage);
            List<Extra> actual = repo.ReadAll();
            Extra actuall = actual.Last();
            Assert.IsTrue(comparer(extage, actuall));

            repo.Delete(extage.Id);
            expected.Remove(extage);

            Assert.IsTrue(listcomparer(repo.ReadAll(), expected));

        }

        [TestMethod()]
        public void EditTest()
        {
            Extra extage = repo.Find(1);
            extage.name = "Updated";
            repo.Edit(extage);
            Extra actual = repo.Find(1);
            Assert.IsTrue(comparer(extage, actual));
        }

    }
}