using System.Data.Entity;

namespace DomainModel
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
    }
}