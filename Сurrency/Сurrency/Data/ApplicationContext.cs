using Microsoft.EntityFrameworkCore;
using Сurrency.Models;
namespace Сurrency.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<UserCurrency> UserCurrencies { get; set; }
    }
}
