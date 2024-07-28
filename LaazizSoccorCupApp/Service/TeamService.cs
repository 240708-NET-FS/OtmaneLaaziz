using LaazizSoccorCupApp.DAO;
using LaazizSoccorCupApp.Entities;



namespace LaazizSoccorCupApp.Service;

public class TeamService : IService<Team>
{
     private readonly TeamDAO _teamDAO;

    public TeamService(TeamDAO teamDAO)
    {
        _teamDAO = teamDAO;
    }



 

    public void Create(Team item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Team item)
    {
        throw new NotImplementedException();
    }

    public ICollection<Team> GetAll()
    {
         return _teamDAO.GetAll();
               
    }

  
    public Team GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public void Update(Team item)
    {
        throw new NotImplementedException();
    }
}
