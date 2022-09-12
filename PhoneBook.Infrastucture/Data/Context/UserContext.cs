using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Entity;

namespace PhoneBook.Infrastucture.Data.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> dbContext)
            : base(dbContext)
        {

        }
    }
}
