namespace LaazizSoccorCupApp.Entities;

public class Team
{
    public int TeamID {get;set;}
    public string TeamName {get;set;}
    public string Coach {get;set;}
    public string Country {get;set;}
    public string FoundedYear {get;set;}

    public Player Player {get;set;}
    public ICollection<Player> Players { get; set; }


    public override string ToString()
    {
        
        return $"{TeamID} | {TeamName} | {Coach} | {Country} | {FoundedYear}";
    }

}