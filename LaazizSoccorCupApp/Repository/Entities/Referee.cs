namespace LaazizSoccorCupApp.Entities;



public class Referee
{
    public int RefereeId { get; set; }
    public string RefereeName { get; set; }
    // Other properties as needed


    public override string ToString()
    {
        return $"{RefereeId} {RefereeName} ";
    }
}

 