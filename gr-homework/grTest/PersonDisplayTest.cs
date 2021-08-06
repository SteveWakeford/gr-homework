using gr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace grTest
{
    [TestClass]
    public class PersonDisplayTest
    {
        [TestMethod]
        public void Output1DisplaysOneItem()
        {
            var person = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));

            var personSet = new HashSet<Person>() { person };

            var stringWriter = new StringWriter();

            PersonDisplay.Output1(personSet, stringWriter);

            var expected = person.ToString() + Environment.NewLine;

            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void Output2DisplaysOneItem()
        {
            var person = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));

            var personSet = new HashSet<Person>() { person };

            var stringWriter = new StringWriter();

            PersonDisplay.Output2(personSet, stringWriter);

            var expected = person.ToString() + Environment.NewLine;

            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void Output3DisplaysOneItem()
        {
            var person = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1900"));

            var personSet = new HashSet<Person>() { person };

            var stringWriter = new StringWriter();

            PersonDisplay.Output3(personSet, stringWriter);

            var expected = person.ToString() + Environment.NewLine;

            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void Output1DisplaysNoItems()
        {
            var personSet = new HashSet<Person>();

            var stringWriter = new StringWriter();

            PersonDisplay.Output1(personSet, stringWriter);

            var expected = string.Empty;

            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void Output2DisplaysNoItems()
        {
            var personSet = new HashSet<Person>();

            var stringWriter = new StringWriter();

            PersonDisplay.Output2(personSet, stringWriter);

            var expected = string.Empty;

            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void Output3DisplaysNoItems()
        {
            var personSet = new HashSet<Person>();

            var stringWriter = new StringWriter();

            PersonDisplay.Output3(personSet, stringWriter);

            var expected = string.Empty;

            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void Output1DisplaysSortedByFavoriteColorThenLastName()
        {
            var person1 = new Person("Adams", "FirstName", "Email", "Blue", DateTime.Parse("1/1/1900"));
            var person2 = new Person("Williams", "FirstName", "Email", "Blue", DateTime.Parse("1/1/1900"));
            var person3 = new Person("Adams", "FirstName", "Email", "Yellow", DateTime.Parse("1/1/1900"));
            var person4 = new Person("Williams", "FirstName", "Email", "Yellow", DateTime.Parse("1/1/1900"));

            var personSet = new HashSet<Person>() { person4, person3, person2, person1 };

            var stringWriter = new StringWriter();

            PersonDisplay.Output1(personSet, stringWriter);

            var expected =
                person1.ToString() + Environment.NewLine +
                person2.ToString() + Environment.NewLine +
                person3.ToString() + Environment.NewLine +
                person4.ToString() + Environment.NewLine;

            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void Output2DisplaysSortedByDateOfBirth()
        {
            var person1 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1901"));
            var person2 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1902"));
            var person3 = new Person("LastName", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1903"));

            var personSet = new HashSet<Person>() { person3, person2, person1 };

            var stringWriter = new StringWriter();

            PersonDisplay.Output2(personSet, stringWriter);

            var expected =
                person1.ToString() + Environment.NewLine +
                person2.ToString() + Environment.NewLine +
                person3.ToString() + Environment.NewLine;

            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void Output3DisplaysSortedByLastNameDescending()
        {
            var person1 = new Person("Williams", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1901"));
            var person2 = new Person("Smythe", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1902"));
            var person3 = new Person("Baker", "FirstName", "Email", "FavoriteColor", DateTime.Parse("1/1/1903"));

            var personSet = new HashSet<Person>() { person3, person2, person1 };

            var stringWriter = new StringWriter();

            PersonDisplay.Output3(personSet, stringWriter);

            var expected =
                person1.ToString() + Environment.NewLine +
                person2.ToString() + Environment.NewLine +
                person3.ToString() + Environment.NewLine;

            Assert.AreEqual(expected, stringWriter.ToString());
        }
    }
}
