
//using Examen.Models.User;
using EXAMEN.Models.Dog;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //public DbSet<User> Users { get; set; }

    public DbSet<Dog> Dogs { get; set; }

}
