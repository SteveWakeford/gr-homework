using gr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void SamePersonIsEqual()
        {
            Person p1 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));
            Person p2 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void SamePersonIsEqualWithSomeNulls()
        {
            Person p1 = new Person("LastName", null, "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));
            Person p2 = new Person("LastName", null, "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void SamePersonHasSameHashCode()
        {
            Person p1 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));
            Person p2 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));

            Assert.AreEqual(p1.GetHashCode(), p2.GetHashCode());
        }

        [TestMethod]
        public void DifferentPersonIsNotEqual()
        {
            Person p1 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));
            Person p2 = new Person("DifferentLastName", "DifferentFirstName", "Differentmail", "DifferentFavoriteColor", DateTime.Parse("2/2/1902"));

            Assert.AreNotEqual(p1, p2);
        }

        [TestMethod]
        public void DifferentPersonHasDifferentHashCode()
        {
            Person p1 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));
            Person p2 = new Person("DifferentLastName", "DifferentFirstName", "Differentmail", "DifferentFavoriteColor", DateTime.Parse("2/2/1902"));

            Assert.AreNotEqual(p1.GetHashCode(), p2.GetHashCode());
        }

        [TestMethod]
        public void NullPersonIsNotEqual()
        {
            Person p1 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));
            Person p2 = null;

            Assert.AreNotEqual(p1, p2);
        }
    }
}
