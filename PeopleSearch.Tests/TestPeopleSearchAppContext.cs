using System;
using System.Data.Entity;
using PeopleSearch.Models;
using System.Threading.Tasks;
using System.Threading;

namespace PeopleSearch.Tests
{
    public class TestPeopleSearchAppContext : IPeopleContext
    {
        public TestPeopleSearchAppContext()
        {
            this.People = new TestPeopleDbSet();
        }

        public DbSet<People> People { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(People people) { }
        public void Dispose() { }
        public Task<int> SaveChangesAsync() {
            return null;          
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken) {
            return null;
        }
    }
}