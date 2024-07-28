
using LaazizSoccorCupApp.Entities;
using Microsoft.EntityFrameworkCore;
namespace LaazizSoccorCupApp.DAO;

public class RefereeDAO : IDAO<Referee>
{
    private readonly ApplicationDbContext _context;

    public RefereeDAO(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Referee item)
    {
          if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        // Add the new Referee entity to the context
        _context.Referees.Add(item);

        // Save changes to the database
        _context.SaveChanges();
    }

    public void Delete(Referee item)
    {
          if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        // Optionally, you may want to attach the entity if it's not already tracked
        if (!_context.Referees.Local.Any(r => r.RefereeId == item.RefereeId))
        {
            _context.Referees.Attach(item);
        }

        // Remove the entity from the context
        _context.Referees.Remove(item);

        // Save changes to the database
        _context.SaveChanges();
    }

    public ICollection<Referee> GetAll()
    {
         // Retrieve all Referee entities from DbSet
        var referees = _context.Referees.ToList();

        return referees;
        
    }

    public Referee GetById(int ID)
    {
        // Query the DbSet for a Referee with the given ID
        var referee = _context.Referees.FirstOrDefault(r => r.RefereeId == ID);

        return referee; // Return the found Referee or null if not found
    }

    public void Update(Referee newItem)
    {
        if (newItem == null)
        {
            throw new ArgumentNullException(nameof(newItem));
        }

        // Retrieve the existing Referee entity by its ID
        var existingReferee = _context.Referees.Find(newItem.RefereeId);

        if (existingReferee == null)
        {
            throw new ArgumentException($"Referee with ID {newItem.RefereeId} not found");
            // You can handle this case based on your application's requirements,
            // such as returning an error or logging the issue.
        }

        // Update the properties of the existing entity
        existingReferee.RefereeName = newItem.RefereeName;
        
        // Update other properties as needed

        // Save the changes to the database
        _context.SaveChanges();
    }
}
