using System;
using Azure.Core.Pipeline;
using LaazizSoccorCupApp.Controller;
using LaazizSoccorCupApp.DAO;
using LaazizSoccorCupApp.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LaazizSoccorCupApp.Entities;

public class Program
{
    private readonly MyLinqClass _matchService;

    public Program(MyLinqClass matchService)
    {
        _matchService = matchService;
    }

    public static void Main(string[] args)
    {

     Console.WriteLine("Please enter user or admin :");
     string input =Console.ReadLine();
    
    while(true)
    {
        

            if(input =="admin")
            {
                Console.WriteLine("Pick from the menu :   ");
                Console.WriteLine("1- add a team   ");
                Console.WriteLine("2- add a player ");
                Console.WriteLine("3- add a referee ");
                Console.WriteLine("4- add a statdium ");
                Console.WriteLine("5- quit the menu");

        
                int number=Convert.ToInt32(Console.ReadLine());
            while(true)
            {
                if (number ==1)
                {
                    TeamController addTeam = new TeamController();
                    addTeam.addTeam();
           

                }
    
                if (number == 2)
                {
                    PlayerController addPlayer = new PlayerController();
                    addPlayer.addPlayer();

                }
     
                if (number == 3)
                {
                    RefereeController addReferee = new RefereeController();
                    addReferee.addReferee();

                }
    
                if (number == 4)
                {
                    StadiumController addStadium = new StadiumController();
                    addStadium.addStadium();

                }
        

                else 
                {
                    Console.WriteLine("try again");
                    Console.WriteLine("Pick from the menu :   ");
                    Console.WriteLine("1- add a team   ");
                    Console.WriteLine("2- add a player ");
                    Console.WriteLine("3- add a referee ");
                    Console.WriteLine("4- add a statdium ");
            
                    number=Convert.ToInt32(Console.ReadLine());


                }

            }

        }


            if (input == "user")
            {
            UserSelectionController userSelection = new UserSelectionController();
            userSelection.userSelection();
            }

            else
            {
             Console.WriteLine("Wrong input please try again");
             Console.WriteLine("Please enter user or admin :");
             input =Console.ReadLine();

            }

    }
             
        


    }







    public void ScheduleMatch()
    {
        for (int i =0;i<3;i++){
        var (team1, team2, referee, stadium) = _matchService.PickRandomTeamsAndOfficials();
        
        Console.WriteLine($" Grame {i+1} ");
        Console.WriteLine($"=====================");
        Console.WriteLine($"{team1.TeamName}" + " ||  " +$"{team2.TeamName}");
        Console.WriteLine($"       Referee      ");
        Console.WriteLine($"     {referee.RefereeName}    ");
        Console.WriteLine($"        Stadium         ");
        Console.WriteLine($"     {stadium.StadiumName}   ");
        Console.WriteLine($"=====================");

        // Perform additional logic here as needed
        }
    }
}
