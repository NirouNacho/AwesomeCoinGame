using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**
 * 1) Menu
 * 2) InGame
 * 3) GameOver
 * 4) Pause
 * 
 * **/

enum DaysOfTheWeek { 
Lunes,
Martes,
Miercoles,
Jueves,
Viernes,
Sabado,
Domingo
}

public class GameManager : MonoBehaviour
{
    DaysOfTheWeek currentDay = DaysOfTheWeek.Domingo;

    // Starts our game
    public void StartGame()
    {
        print("Hoy es " + (int)currentDay);
    }

    private void Start()
    {
        StartGame();
    }

    // Called when palyer dies
    public void GameOver()
    {
        
    }
    //Called when player quit the game and go to the main menu
    public void BackToMainMenu() 
    { 

    }
}
