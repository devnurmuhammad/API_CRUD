using API_CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.DataContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
    