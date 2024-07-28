namespace LaazizSoccorCupApp.Entities;

public class Player
{
    public int PlayerID {get;set;}
    public string PlayerName {get;set;}
    public int Age {get;set;}
    public string Position {get;set;}
    public int TeamID  {get;set;}

    public Team Team {get;set;}


    public override string ToString()
    {
       
        //return $"{PlayerID}    {PlayerName}    {Age}     {Position}    {TeamID}     {Team}";
        return $"{PlayerID,-10} | {PlayerName,-20} | {Age,-3} | {Position,-10} | {TeamID,-5}";
    }

}