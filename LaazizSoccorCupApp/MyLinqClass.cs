
namespace LaazizSoccorCupApp.Entities;


using System;
using System.Linq;

public class MyLinqClass
{
    private readonly ApplicationDbContext _context;
    private readonly Random _random;

    public MyLinqClass(ApplicationDbContext context)
    {
        _context = context;
        _random = new Random();
    }

    public (Team Team1, Team Team2, Referee Referee, Stadium Stadium) PickRandomTeamsAndOfficials()
    {
        // Select two random teams
        var teams = _context.Teams.ToList();
        var team1 = teams[_random.Next(0, teams.Count)];
        var team2 = teams[_random.Next(0, teams.Count)];
        
        // Make sure team1 and team2 are different
        while (team2.TeamID == team1.TeamID)
        {
            team2 = teams[_random.Next(0, teams.Count)];
        }

        // Select a random referee
        var referees = _context.Referees.ToList();
        var referee = referees[_random.Next(0, referees.Count)];

        // Select a random stadium
        var stadiums = _context.Stadiums.ToList();
        var stadium = stadiums[_random.Next(0, stadiums.Count)];
         

        return (team1, team2, referee, stadium);
    }

    
}
