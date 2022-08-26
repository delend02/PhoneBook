using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Entity;

namespace PhoneBook.Infrastucture.Data.Context
{
    public class PhoneContext : DbContext
    {
        public DbSet<TelephoneBook> Books { get; set; }

        public PhoneContext(DbContextOptions<PhoneContext> dbContext) 
            : base(dbContext)
        {

        }
    }
}
