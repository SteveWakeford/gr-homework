using grWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace grTest
{
    // Fake record persistence is a static field, don't run these tests in parallel

    [TestClass]
    public class RecordsControllerTest
    {
        private static void PostBody(RecordsController recordsController, string body)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(body, Encoding.UTF8, "text/plain")
            };

            recordsController.Request = httpRequestMessage;

            recordsController.Post();
        }

        [TestMethod]
        public void PostAcceptsOneLine()
        {
            var recordsController = new RecordsController();

            var line1 = "Bunny, Bugs, bugs@warnerbros.com, Gray, 6/6/1955";

            RecordsController.Persons.Clear();
            PostBody(recordsController, line1);
        }

        [TestMethod]
        public void PostAcceptsThreeLines()
        {
            var recordsController = new RecordsController();

            var line1 = "Bunny, Bugs, bugs@warnerbros.com, Gray, 6/6/1955";
            var line2 = "Devil | Taz | taz@someisland.net | Brown | 7/7/1977";
            var line3 = "Mouse Mickey mickey@disney.com Red 2/1/1910";

            RecordsController.Persons.Clear();
            PostBody(recordsController, line1);
            PostBody(recordsController, line2);
            PostBody(recordsController, line3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PostDoesNotAcceptInvalidLine()
        {
            var recordsController = new RecordsController();

            var line1 = "No Good";

            PostBody(recordsController, line1);
        }

        [TestMethod]
        public void GetSortedByColorIsSorted()
        {
            var recordsController = new RecordsController();

            var line1 = "Bunny, Bugs, bugs@warnerbros.com, Gray, 6/6/1955";
            var line2 = "Devil | Taz | taz@someisland.net | Brown | 7/7/1977";
            var line3 = "Mouse Mickey mickey@disney.com Red 2/1/1910";

            RecordsController.Persons.Clear();
            PostBody(recordsController, line1);
            PostBody(recordsController, line2);
            PostBody(recordsController, line3);

            var sorted = recordsController.GetSortedByColor();

            Assert.AreEqual(sorted.ToList()[0].FavoriteColor, "Brown");
            Assert.AreEqual(sorted.ToList()[1].FavoriteColor, "Gray");
            Assert.AreEqual(sorted.ToList()[2].FavoriteColor, "Red");
        }

        [TestMethod]
        public void GetSortedByDateOfBirthIsSorted()
        {
            var recordsController = new RecordsController();

            var line1 = "Bunny, Bugs, bugs@warnerbros.com, Gray, 6/6/1955";
            var line2 = "Devil | Taz | taz@someisland.net | Brown | 7/7/1977";
            var line3 = "Mouse Mickey mickey@disney.com Red 2/1/1910";

            RecordsController.Persons.Clear();
            PostBody(recordsController, line1);
            PostBody(recordsController, line2);
            PostBody(recordsController, line3);

            var sorted = recordsController.GetSortedByDateOfBirth();

            Assert.AreEqual(sorted.ToList()[0].DateOfBirth, DateTime.Parse("2/1/1910"));
            Assert.AreEqual(sorted.ToList()[1].DateOfBirth, DateTime.Parse("6/6/1955"));
            Assert.AreEqual(sorted.ToList()[2].DateOfBirth, DateTime.Parse("7/7/1977"));
        }

        [TestMethod]
        public void GetSortedByLastNameIsSorted()
        {
            var recordsController = new RecordsController();

            var line1 = "Bunny, Bugs, bugs@warnerbros.com, Gray, 6/6/1955";
            var line2 = "Devil | Taz | taz@someisland.net | Brown | 7/7/1977";
            var line3 = "Mouse Mickey mickey@disney.com Red 2/1/1910";

            RecordsController.Persons.Clear();
            PostBody(recordsController, line1);
            PostBody(recordsController, line2);
            PostBody(recordsController, line3);

            var sorted = recordsController.GetSortedByLastName();

            Assert.AreEqual(sorted.ToList()[0].LastName, "Bunny");
            Assert.AreEqual(sorted.ToList()[1].LastName, "Devil");
            Assert.AreEqual(sorted.ToList()[2].LastName, "Mouse");
        }
    }
}
