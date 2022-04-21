using InAndOut.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InAndOut.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items{ get; set; }
        public DbSet<MyExpenses> Expenses { get; set; }
        public DbSet<ExpensesType> ExpensesTypes { get; set; }
        public object ExpensesType { get; internal set; }
    }
}
