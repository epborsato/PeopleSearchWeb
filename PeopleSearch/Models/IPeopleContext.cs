using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    public interface IPeopleContext : IDisposable
    {
        DbSet<People> People { get; set; }
        void MarkAsModified(People people);
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
