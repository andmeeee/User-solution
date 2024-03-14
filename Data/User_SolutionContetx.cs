using Microsoft.EntityFrameworkCore;
using User_solution.Data.Entities;
 
namespace User_solution.Data;
 
public class User_solutionContext : DbContext
{
    public User_solutionContext(DbContextOptions<User_solutionContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
}