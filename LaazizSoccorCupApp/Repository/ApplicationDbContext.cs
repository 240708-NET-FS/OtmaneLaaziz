using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LaazizSoccorCupApp.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

    public ApplicationDbContext(){}


    public DbSet<Player> Players {get;set;}
    public DbSet<Team> Teams {get;set;}
    public DbSet<Referee> Referees { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json")
                                            .Build();
            
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            
            

        

      
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Player entity
        modelBuilder.Entity<Player>()
            .HasKey(p => p.PlayerID);

        // Configure Team entity
        modelBuilder.Entity<Team>()
            .HasKey(t => t.TeamID);

        // Configure one-to-many relationship: One Team has many Players
        modelBuilder.Entity<Team>()
            .HasMany(t => t.Players)        // One Team has many Players
            .WithOne(p => p.Team)           // Each Player belongs to one Team
            .HasForeignKey(p => p.TeamID); // Foreign key in Player entity

        // Optionally, configure cascading delete behavior if needed
        // modelBuilder.Entity<Team>()
        //     .HasMany(t => t.Players)
        //     .WithOne(p => p.Team)
        //     .HasForeignKey(p => p.TeamId)
        //     .OnDelete(DeleteBehavior.Cascade);
    }

    public object Setup(Func<object, object> value)
    {
        throw new NotImplementedException();
    }
}