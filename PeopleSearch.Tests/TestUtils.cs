using Moq;
using PeopleSearch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Tests
{
    class TestUtils
    {
        public static People GetDemoPeople(int demoNumber)
        {
            return new People { Id = demoNumber, FirstName = "FN" + demoNumber, LastName = "LN" + demoNumber, Address = demoNumber + " S State st", Age = demoNumber * 10, Interests = "Interest" + demoNumber };
        }
    }
}
