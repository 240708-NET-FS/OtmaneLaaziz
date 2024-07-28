using LaazizSoccorCupApp.DAO;
using LaazizSoccorCupApp.Entities;
using LaazizSoccorCupApp.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace LaazizSoccorCupApp.Controller;

public class StadiumController
{
    public void addStadium()
    {
        var context = new ApplicationDbContext();
        Console.WriteLine("Enter stadiuam name :");
        string stadiumname =Console.ReadLine();
        
        StadiuamDAO stadiuamDAO = new StadiuamDAO(context);
        stadiuamDAO.Create(new Stadium {StadiumName=stadiumname});

    }
}