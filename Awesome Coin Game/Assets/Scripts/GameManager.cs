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

public enum GameState {
    Menu, InGame, GameOver, Pause
} 

public class GameManager : MonoBehaviour
{
    //Starts pur game
    // DaysOfTheWeek currentDay = DaysOfTheWeek.Domingo;

    public GameState currentGameState = GameState.Menu;
    private static GameManager sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameManager GetInstance() 
    {
        return sharedInstance;
    }

    // Starts our game
    public void StartGame()
    {
        
        currentGameState = GameState.Menu;

    }
   
    private void Start()
    {
        //StartGame();
        currentGameState = GameState.Menu;
    }

    private void Update()
    {
        if (Input.GetButtonDown("s")) 
        {
            ChangeGameState(GameState.InGame);
        }
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
        /* if (newGameState == GameState.Menu)
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
        else{
        currentGameState = GameState.Menu;
         }
        */

        switch (newGameState)
        {
            case GameState.Menu:
                //Let show the menu scene
                break;
            case GameState.InGame:
                //Unity must show the Real Game
                break;
            case GameState.GameOver:
                // Lets load end of the game scene
                break;
            default:
                currentGameState = GameState.Menu;
                break;

        }
        currentGameState = newGameState;

    }

}
