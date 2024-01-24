
//using Examen.Models.User;
using EXAMEN.Models.Dog;
using EXAMEN.Models.Owner;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //public DbSet<User> Users { get; set; }

    public DbSet<Dog> Dogs { get; set; }

    public DbSet<Owner> Owners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dog>()
            .HasOne<Owner>(d => d.Owner)
            .WithMany(o => o.Dogs)
            .HasForeignKey(d => d.OwnerId);
        base.OnModelCreating(modelBuilder);
    }

}
