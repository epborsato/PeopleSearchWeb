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
    public class PeopleControllerTest
    {
        [TestMethod]

        public void GetPeople_ShouldReturnAllPeople()
        {
            //Arrange
            const int expectedId = 1;
            var expected = TestUtils.GetDemoPeople (1);
            var data = new List<People>
            {
                expected,
                TestUtils.GetDemoPeople(2),
                TestUtils.GetDemoPeople(3),
                TestUtils.GetDemoPeople(4)
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

            var classUnderTest = new PeopleController(customDbContextMock.Object);

            //Action
            var actual = classUnderTest.GetPeople(expectedId);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);

        }
        
    }
    
}
