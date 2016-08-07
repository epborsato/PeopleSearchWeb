using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Models;
using PeopleSearch.Controllers;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Linq;
using Moq;
using System.Data.Entity;

namespace PeopleSearch.Tests
{
    [TestClass]
    public class SearchControllerTest
    {
        [TestMethod]

        public void GetPeople_ShouldFindMatchingFirstName()
        {
            //Arrange
            const string expectedFirstName = "FN";
            var expected = TestUtils.GetDemoPeople(1);
            var data = new List<People>
            {
                expected,
                TestUtils.GetDemoPeople(2),
                TestUtils.GetDemoPeople(3),
                TestUtils.GetDemoPeople(4),
                new People { Id = 5, FirstName = "FIRSTNAME" , LastName = "LN", Address = " S State st", Age = 10, Interests = "Interest"  }
            }.AsQueryable();

            var dbSetMock = new Mock<IDbSet<People>>();
            dbSetMock.Setup(m => m.Provider).Returns(data.Provider);
            dbSetMock.Setup(m => m.Expression).Returns(data.Expression);
            dbSetMock.Setup(m => m.ElementType).Returns(data.ElementType);
            dbSetMock.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var customDbContextMock = new Mock<PeopleContext>();
            customDbContextMock
                .Setup(x => x.People)
                .Returns(dbSetMock.Object);

            var classUnderTest = new SearchController(customDbContextMock.Object);

            //Action
            var actual = classUnderTest.GetPeople(expectedFirstName);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(4, actual.Count());
            Assert.IsTrue(actual.ElementAt(0).FirstName.StartsWith(expectedFirstName));
            Assert.IsTrue(actual.ElementAt(1).FirstName.StartsWith(expectedFirstName));
            Assert.IsTrue(actual.ElementAt(2).FirstName.StartsWith(expectedFirstName));
            Assert.IsTrue(actual.ElementAt(3).FirstName.StartsWith(expectedFirstName));

        }



    }

}
