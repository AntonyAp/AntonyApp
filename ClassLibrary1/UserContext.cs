using System.Data.Entity;

namespace testtest.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
    }
}