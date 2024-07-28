using LaazizSoccorCupApp.DAO;
using LaazizSoccorCupApp.Entities;
using LaazizSoccorCupApp.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace LaazizSoccorCupApp.Controller;

public class TeamController
{
    

    private TeamService teamService;

  
  


    
   


    public void addTeam()
    {
        string input="";
        int count = 0;
        while(input !="q")
        {
        var context = new ApplicationDbContext();
        Console.WriteLine("Enter team name :");
        string teamname =Console.ReadLine();
        Console.WriteLine("Enter Coach name : ");
        string coach =Console.ReadLine();
        Console.WriteLine("Enter country : ");
        string country=Console.ReadLine();
        Console.Write("Enter founded year");
        string foundedyear=Console.ReadLine();
        TeamDAO teamDAO = new TeamDAO(context);
        teamDAO.Create(new Team {TeamName=teamname,Coach=coach,Country=country,FoundedYear=foundedyear});
        Console.WriteLine("Enter q to quit or any key to continue");
        input=Console.ReadLine();
       
        count++;
        
        }
       
    }


}