using LaazizSoccorCupApp.DAO;
using LaazizSoccorCupApp.Entities;
using LaazizSoccorCupApp.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace LaazizSoccorCupApp.Controller;
public class PlayerController
{
    
    public void addPlayer()
    {
      var context = new ApplicationDbContext();
         Console.WriteLine("Enter player name :");
        string playername =Console.ReadLine();
        Console.WriteLine("Enter player age : ");
        int age =Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter player position : ");
        string position=Console.ReadLine();
        Console.WriteLine("Enter team ID :");
        int teamID=Convert.ToInt32(Console.ReadLine());
        PlayerDAO playerDAO = new PlayerDAO(context);
        playerDAO.Create(new Player {PlayerName=playername,Age=age,Position=position,TeamID=teamID});
    }
}