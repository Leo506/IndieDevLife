using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player 
{
    
    static int skillPoint = 0;

   

    public static int GetSkillPoints()
    {
        return skillPoint;
    }


    public static void UseSkillPoint()
    {
        skillPoint--;
    }


    public static void AddSkillPoint(int value)
    {
        skillPoint += value;
    }


    public static void ResetData() {
        
        skillPoint = 0;
    }

    

    public static void SetPlayer(int points) {
        
        skillPoint = points;
    }
}
