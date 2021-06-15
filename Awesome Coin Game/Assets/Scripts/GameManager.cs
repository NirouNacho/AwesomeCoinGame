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

public enum GameState {
    Menu, InGame, GameOver, Pause
} 

public class GameManager : MonoBehaviour
{
    //Starts pur game
    // DaysOfTheWeek currentDay = DaysOfTheWeek.Domingo;

    GameState currentGameState = GameState.Menu;


    // Starts our game
    public void StartGame()
    {
        // print("Hoy es " + (int)currentDay);

        ChangeGameState(GameState.InGame);

    }

    private void Start()
    {
        StartGame();
    }

    // Called when palyer dies
    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
    }
    //Called when player quit the game and go to the main menu
    public void BackToMainMenu() 
    {
        ChangeGameState(GameState.Menu);
    }

    private void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.Menu)
        {
            //Let show the menu scene
        }
        else if (newGameState == GameState.InGame)
        {
            //Unity must show the Real Game
        }
        else if (newGameState == GameState.GameOver) 
        {
            // Lets load end of the game scene
        }

        currentGameState = newGameState;

    }

}
