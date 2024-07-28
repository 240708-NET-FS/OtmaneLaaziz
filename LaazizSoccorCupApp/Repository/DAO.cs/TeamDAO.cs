using LaazizSoccorCupApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaazizSoccorCupApp.DAO;

public class TeamDAO : IDAO<Team>
{
    private ApplicationDbContext _context;

    public TeamDAO(ApplicationDbContext context)
    {
        _context = context;
    }


    
    public void Create(Team item)
    {
        _context.Teams.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Team item)
    {
        _context.Teams.Remove(item);
        _context.SaveChanges();
    }

    public ICollection<Team> GetAll()
    {
        List<Team> Teams = _context.Teams.Include(l => l.Player)
                                            .ToList();
        return Teams;
    }

    public Team GetById(int ID)
    {
        Team Team = _context.Teams
                            .Include(l => l.Player)
                            .FirstOrDefault(l => l.TeamID == ID);

        return Team;
    }

    public void Update(Team newItem)
    {
       // Find the existing Team entity by its ID
        var existingTeam = _context.Teams.Find(newItem.TeamID);

        if (existingTeam == null)
        {
            throw new ArgumentException($"Team with ID {newItem.TeamID} not found");
            // You can handle this case based on your application's requirements,
            // such as returning an error or logging the issue.
        }

        // Update the properties of the existing entity
        existingTeam.TeamName = newItem.TeamName;
        // Update other properties as needed

        // If there are related entities (e.g., Players), manage their updates as well
        // For example:
        // existingTeam.Players.Clear(); // Clear existing players
        // foreach (var player in newItem.Players)
        // {
        //     existingTeam.Players.Add(player); // Add or update players
        // }

        // Save the changes to the database
        _context.SaveChanges();
    }
}
