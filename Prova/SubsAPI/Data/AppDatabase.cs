namespace SubsAPI.Data;
using Microsoft.EntityFrameworkCore;
using SubsAPI.Models;

public class AppDatabase : DbContext
{
    public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<IMC> IMCs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>()
            .HasKey(a => a.Id);
        
        modelBuilder.Entity<IMC>()
            .HasKey(i => i.Id);

        base.OnModelCreating(modelBuilder);
    }
}