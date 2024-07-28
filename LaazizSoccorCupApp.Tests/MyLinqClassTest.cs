using Microsoft.EntityFrameworkCore;
using Xunit;
using LaazizSoccorCupApp.Entities;
using LaazizSoccorCupApp.DAO;
using System.Linq;

public class MyLinqClassTests
{
    private readonly ApplicationDbContext _context;
    private readonly MyLinqClass _myLinqClass;

    public MyLinqClassTests()
    {
        // Set up an in-memory database for testing
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);

        // Seed data
        _context.Teams.AddRange(
            new Team { TeamID = 1, TeamName = "Team A",Coach="Mike",Country="USA",FoundedYear="1933" },
            new Team { TeamID = 2, TeamName = "Team B",Coach="John",Country="Argentina",FoundedYear="1922"  },
            new Team { TeamID = 3, TeamName = "Team C",Coach="Marcelo",Country="Spain",FoundedYear="1973"  }
        );
        _context.Referees.AddRange(
            new Referee { RefereeId = 1, RefereeName = "Referee A" },
            new Referee { RefereeId = 2, RefereeName = "Referee B" }
        );
        _context.Stadiums.AddRange(
            new Stadium { StadiumId = 1, StadiumName = "Stadium A" },
            new Stadium { StadiumId = 2, StadiumName = "Stadium B" }
        );
        _context.SaveChanges();
        _myLinqClass = new MyLinqClass(_context);

        
    }

    [Fact]
    public void PickRandomTeamsAndOfficials_ShouldReturnDifferentTeams()
    {
        // Act
        var result = _myLinqClass.PickRandomTeamsAndOfficials();
       
    
    

        // Assert
        Assert.NotNull(result.Team1);
        Assert.NotNull(result.Team2);
        Assert.NotEqual(result.Team1.TeamID, result.Team2.TeamID);
        Assert.NotNull(result.Referee);
        Assert.NotNull(result.Stadium);
       
   
    }

   

  
   
}
