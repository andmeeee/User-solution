using Microsoft.EntityFrameworkCore;
using User_solution.Data.Entities;
 
namespace User_solution.Data;
 
public class User_solutionContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public User_solutionContext(DbContextOptions<User_solutionContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
}
