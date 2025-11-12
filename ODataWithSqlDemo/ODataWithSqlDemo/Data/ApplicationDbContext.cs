using Microsoft.EntityFrameworkCore;
using ODataWithSqlDemo.Models;
using System;

namespace ODataWithSqlDemo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
