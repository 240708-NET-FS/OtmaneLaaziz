
using LaazizSoccorCupApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaazizSoccorCupApp.DAO;

public class StadiuamDAO : IDAO<Stadium>
{
     private ApplicationDbContext _context;

    public StadiuamDAO(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Stadium item)
    {
        _context.Stadiums.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Stadium item)
    {
         _context.Stadiums.Remove(item);
        _context.SaveChanges();
    }

    public ICollection<Stadium> GetAll()
    {
        List<Stadium> stadiums = _context.Stadiums.ToList();

        return stadiums;
    }

    public Stadium GetById(int ID)
    {
        var stadium = _context.Stadiums
                              .FirstOrDefault(s => s.StadiumId ==ID );

        return stadium; // Return the found Stadium or null if not found
        
    }

    public void Update(Stadium newItem)
    {
         // Find the existing Stadium entity by its ID
        var existingStadium = _context.Stadiums.Find(newItem.StadiumId);

        if (existingStadium == null)
        {
            throw new ArgumentException($"Stadium with ID {newItem.StadiumId} not found");
            // You can handle this case based on your application's requirements,
            // such as returning an error or logging the issue.
        }

        // Update the properties of the existing entity
        existingStadium.StadiumName = newItem.StadiumName;
       
        // Update other properties as needed

        // Save the changes to the database
        _context.SaveChanges();
    }
}
