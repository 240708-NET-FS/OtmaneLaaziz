
namespace LaazizSoccorCupApp.Entities;
public class Stadium
{
    public int StadiumId { get; set; }
    public string StadiumName { get; set; }
    // Other properties as needed


    public override string ToString()
    {
        return $"{StadiumId} {StadiumName} ";
    }
}