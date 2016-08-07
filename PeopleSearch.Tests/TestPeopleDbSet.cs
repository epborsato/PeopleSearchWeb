using System;
using System.Linq;
using PeopleSearch.Models;

namespace PeopleSearch.Tests
{
    class TestPeopleDbSet : TestDbSet<People>
    {
        public override People Find(params object[] keyValues)
        {
            return this.SingleOrDefault(people => people.Id == (int)keyValues.Single());
        }
    }
}