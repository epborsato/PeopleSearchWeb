using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Models;
using PeopleSearch.Controllers;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace PeopleSearch.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void GetPeople_ShouldReturnAllPeople()
        {
            ////Arrange
            //var controller = new PeopleController();

            ////Act
            //var result = controller.GetPeople() as List<People>;

            ////Assert
            //Assert.AreEqual(result.Count, result.Count);




            // Arrange
    //        var people = new List<People>
    //{
    //    new People {Id = 1, FirstName = "FN1", LastName = "LN1", Address = "1 S State st", Age = 1, Interests = "Interest1"},
    //    new People {Id = 2, FirstName = "FN2", LastName = "LN2", Address = "2 S State st", Age = 2, Interests = "Interest2"},
    //    new People {Id = 3, FirstName = "FN3", LastName = "LN3", Address = "3 S State st", Age = 3, Interests = "Interest3"}
    //        };
    //        var peopleRepository = new Mock<IFaqRepository>();
    //        faqRepository.Setup(e => e.GetAll()).Returns(faqs.AsQueryable());
    //        var controller = new FaqController(faqRepository.Object);
    //        // Act 
    //        var result = controller.Index() as ViewResult;
    //        var model = result.Model as FaqViewModel;
    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual(3, model.FAQs.Count());
        }

        [TestMethod]
        public void PostPeople_ShouldReturnPeople()
        {
            var controller = new PeopleController(new TestPeopleContext());

            var item = GetDemoPeople(1);

            var result = controller.PostPeople(item);// as CreatedAtRouteNegotiatedContentResult<People>;

            Assert.IsNotNull(result);
            //Assert.AreEqual(result.RouteName, "DefaultApi");
            //Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            //Assert.AreEqual(result.Content.Name, item.Name);
        }

        People GetDemoPeople(int demoNumber)
        {
            return new People { Id = demoNumber, FirstName = "FN"+demoNumber, LastName = "LN"+demoNumber, Address = demoNumber+" S State st", Age = demoNumber*10, Interests = "Interest"+demoNumber };
        }

    }
    
}
