
//using Examen.Models.User;
using EXAMEN.Models.Eveniment;
using EXAMEN.Models.Participant;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //public DbSet<User> Users { get; set; }

    public DbSet<Eveniment> Evenimente { get; set; }

    public DbSet<Participant> Participanti { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Eveniment>()
            .HasMany<Participant>(p => p.Participanti)
            .WithMany(e => e.Evenimente);

        base.OnModelCreating(modelBuilder);

    }

}
