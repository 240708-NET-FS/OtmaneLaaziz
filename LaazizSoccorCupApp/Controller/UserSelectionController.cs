using System.Net.Quic;
using Azure.Core.Pipeline;
using LaazizSoccorCupApp.DAO;
using LaazizSoccorCupApp.Entities;
using LaazizSoccorCupApp.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace LaazizSoccorCupApp.Controller;

public class UserSelectionController
{

     public void userSelection()
    {
        var context = new ApplicationDbContext();
          var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=tcp:sqlserver-example1.database.windows.net,1433;Initial Catalog=SqlDatabase;Persist Security Info=False;User ID=admin1;Password=Arsenalfc31@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            .AddTransient<MyLinqClass>() // Add your services as needed
            .BuildServiceProvider();
       
        Console.WriteLine("Pick from the menu :   ");
        Console.WriteLine("1- Tournament games   ");
        Console.WriteLine("2- Teames ");
        Console.WriteLine("3-Players ");
        Console.WriteLine("4-Referees ");
        Console.WriteLine("5-Stadiums");
        Console.WriteLine("6-Click 6 to quit or any button to continue");

       

        int  number =Convert.ToInt32(Console.ReadLine());


        if(number == 1)
        {
            
            var program = new Program(serviceProvider.GetService<MyLinqClass>());
            program.ScheduleMatch();

         }
        
        else if (number==2)
        {
         TeamDAO teamDao = new TeamDAO(context);
         ICollection<Team> teams = teamDao.GetAll();
         foreach (var team in teams)
             {
                 Console.WriteLine(team);
             }
        }  
        

        else if(number == 3)
        {
        PlayerDAO playerDao = new PlayerDAO(context);
         ICollection<Player> players = playerDao.GetAll();
        Console.WriteLine($"  PlayerID |     PlayerName      |  Age  | Position | TeamID ");
        Console.WriteLine($"------------------------------------------------------------");
         foreach (var player in players)
             {
                
                 Console.WriteLine(player);
                  
             } 
            
        }
        
        else if(number==4)
        {
         RefereeDAO refereeDao = new RefereeDAO(context);
         ICollection<Referee> referees = refereeDao.GetAll();
         foreach (var referee in referees)
             {
                 Console.WriteLine(referee);
             }  
        }
         else if(number==5)
        {
         StadiuamDAO stadiuamDAO = new StadiuamDAO(context);
         ICollection<Stadium> stadiums = stadiuamDAO.GetAll();
         foreach (var stadium in stadiums)
             {
                 Console.WriteLine(stadium);
             }  
        }
            
       
            
            
                
         
                
        
        
        
        
        
       


            Console.WriteLine("Do you want to quit? Type Y or N");

            string input = Console.ReadLine();

           
       
    }

}