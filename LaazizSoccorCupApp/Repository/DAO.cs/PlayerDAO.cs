
using LaazizSoccorCupApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaazizSoccorCupApp.DAO;

public class PlayerDAO : IDAO<Player>
{

    private ApplicationDbContext _context;

    public PlayerDAO(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Player item)
    {
         if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        // Add the new Player entity to the context
        _context.Players.Add(item);

        // Save changes to the database
        _context.SaveChanges();
    }

    public void Delete(Player item)
    {
         if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        // Optionally, you may want to attach the entity if it's not already tracked
        if (!_context.Players.Local.Any(p => p.PlayerID == item.PlayerID))
        {
            _context.Players.Attach(item);
        }

        // Remove the entity from the context
        _context.Players.Remove(item);

        // Save changes to the database
        _context.SaveChanges();
    }

    public ICollection<Player> GetAll()
    {
         // Retrieve all Player entities from DbSet
        var players = _context.Players.ToList();

        return players;
    }

    public Player GetById(int ID)
    {
         // Query the DbSet for a Player with the given ID
        var player = _context.Players.FirstOrDefault(p => p.PlayerID == ID);

        return player; // Return the found Player or null if not found
    }

    public void Update(Player newItem)
    {
          if (newItem == null)
        {
            throw new ArgumentNullException(nameof(newItem));
        }

        // Retrieve the existing Player entity by its ID
        var existingPlayer = _context.Players.Find(newItem.PlayerID);

        if (existingPlayer == null)
        {
            throw new ArgumentException($"Player with ID {newItem.PlayerID} not found");
            // You can handle this case based on your application's requirements,
            // such as returning an error or logging the issue.
        }

        // Update the properties of the existing entity
        existingPlayer.PlayerName = newItem.PlayerName;
        
        existingPlayer.Age = newItem.Age;
        // Update other properties as needed
        existingPlayer.Position = newItem.Position;

        // Save the changes to the database
        _context.SaveChanges();
    }
}
