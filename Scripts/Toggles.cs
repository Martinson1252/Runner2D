using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggles : MonoBehaviour
{
    public BallSpawning B_sp;
    public GameUI ui;
    public void GreenClick()
    {
        
        
        B_sp.BallSymbol = 'G';
        B_sp.SpawnBallInstanlty();
        
        
    }
    public void YellowClick()
    {
      
        B_sp.BallSymbol = 'Y';
        B_sp.SpawnBallInstanlty();
       
        
    }
    public void BlueClick()
    {
        
        B_sp.BallSymbol = 'B';
        B_sp.SpawnBallInstanlty();
       
        
    }
    public void RedClick()
    {
        
        B_sp.BallSymbol = 'R';
        B_sp.SpawnBallInstanlty();
        
        
    }
}
