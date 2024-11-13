using Microsoft.EntityFrameworkCore;
using BorrowLend.Models;

namespace BorrowLend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Създаване на таблица Items в базата данни
        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; } // за таблицата ExpenseTypes
    }
}
