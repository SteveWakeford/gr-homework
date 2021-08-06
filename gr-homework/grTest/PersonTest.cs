using gr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void FromPipeDelimitedLineBuildsPerson()
        {
            var line = "LastName | FirstName | Email | FavoriteColor | 1/1/1900";

            var person = Person.Parse(line);

            Assert.AreEqual(person, new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900")));
        }

        [TestMethod]
        public void FromCommaDelimitedLineBuildsPerson()
        {
            var line = "LastName, FirstName, Email, FavoriteColor, 1/1/1900";

            var person = Person.Parse(line);

            Assert.AreEqual(person, new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900")));
        }

        [TestMethod]
        public void FromSpaceDelimitedLineBuildsPerson()
        {
            var line = "LastName FirstName Email FavoriteColor 1/1/1900";

            var person = Person.Parse(line);

            Assert.AreEqual(person, new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900")));
        }

        [TestMethod]
        public void NullLineBuildsNull()
        {
            string line = null;

            var person = Person.Parse(line);

            Assert.IsNull(person);
        }

        [TestMethod]
        public void NotEnoughPartsBuildsNull()
        {
            var line = "LastName FirstName Email FavoriteColor";

            var person = Person.Parse(line);

            Assert.IsNull(person);
        }

        [TestMethod]
        public void TooManyPartsBuildsNull()
        {
            var line = "LastName FirstName Email FavoriteColor 1/1/1900 1/1/1900";

            var person = Person.Parse(line);

            Assert.IsNull(person);
        }

        [TestMethod]
        public void InvalidDateOfBirthReturnsNull()
        {
            var line = "LastName FirstName Email FavoriteColor Asdf";

            var person = Person.Parse(line);

            Assert.IsNull(person);
        }
    }
}
