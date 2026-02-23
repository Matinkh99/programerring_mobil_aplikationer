using UnityEngine;

public class DodgerAttributes
{
     int current_health;
     int maximum_health;
    int current_score;
    private int startingHealth;
    private int startingScore;

    public DodgerAttributes(int initial_health , int maxhp ,int  curr_score)
    {
        current_health = initial_health;
        maximum_health = maxhp;
        current_score = curr_score;
        
    }

    

    public int getMaxhp()
    {
        
        return this.maximum_health;
    } 
    public int get_health()
    {
        return this.current_health;
    }
    public int getcurr()
    {
        return this.current_score;
    }
    public void setcurr(int health )
    {
        current_health = health;
        
    }
    public void Set_score(int score)
    {
        current_score = score;
    }




    
}

