using LaazizSoccorCupApp.DAO;
using LaazizSoccorCupApp.Entities;
using LaazizSoccorCupApp.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace LaazizSoccorCupApp.Controller;

public class RefereeController
{

   public void addReferee()
{
   try{
     var context = new ApplicationDbContext();
        Console.WriteLine("Enter referee name :");
        string refereename =Console.ReadLine();
         if (string.IsNullOrWhiteSpace(refereename))
                {
                    Console.WriteLine("Referee name cannot be empty. Please enter a valid name.");
                    return;
                }
        
      

}
catch(Exception e)
{
   Console.WriteLine("Something went wrong."+e.Message);

}
   }
}