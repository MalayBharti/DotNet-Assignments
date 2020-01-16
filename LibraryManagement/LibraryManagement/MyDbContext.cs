using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("ConnectionString")
        {
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookIssue> BookIssues { get; set; }
    }
}
