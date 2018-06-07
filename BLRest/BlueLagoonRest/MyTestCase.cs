using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace BlueLagoonRest
{
    [TestFixture]
    public class MyTestCase
    {

        MyMathTest math = new MyMathTest();

        [TestCase]
        public void Add()
        {
            Assert.AreEqual(31, math.Add(20, 11));
        }

        [TestCase]
        public void Sub()
        {
            Assert.AreEqual(10, math.Sub(20, 10));
        }
    }
}