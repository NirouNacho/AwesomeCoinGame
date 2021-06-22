using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public Canvas mainMenu;
    public Canvas gameMenu;
    public Canvas gameOverMenu;
    int collectedCoins = 0;

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
        LevelGenerator.sharedInstance.createInitialBlocks();
        PlayerController.GetInstance().StartGame();
        ChangeGameState( currentGameState = GameState.InGame);
        ViewInGame.GetInstance().ShowHighestScore();
    }
   
    private void Start()
    {
        //StartGame();
        currentGameState = GameState.Menu;
        mainMenu.enabled = true;
        gameMenu.enabled = false;
        gameOverMenu.enabled = false;
    }

    private void Update()
    {
        if (currentGameState!=GameState.InGame && Input.GetButtonDown("s")) 
        {
            ChangeGameState(GameState.InGame);
            StartGame ();
        }
    }
    // Called when palyer dies
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        ChangeGameState(GameState.GameOver);
        GameOverView.GetInstance().UpdateGUI();
    }
    //Called when player quit the game and go to the main menu
    public void BackToMainMenu() 
    {
        ChangeGameState(GameState.Menu);
    }

    private void ChangeGameState(GameState newGameState)
    {

        switch (newGameState)
        {
            case GameState.Menu:
                mainMenu.enabled = true;
                gameMenu.enabled = false;
                gameOverMenu.enabled = false;
                break;
            case GameState.InGame:
                mainMenu.enabled = false;
                gameMenu.enabled = true;
                gameOverMenu.enabled = false;
                break;
            case GameState.GameOver:
                mainMenu.enabled = false;
                gameMenu.enabled = false;
                gameOverMenu.enabled = true;
                break;
            default:
                currentGameState = GameState.Menu;
                break;

        }
        currentGameState = newGameState;

    }

    public void CollectCoins()
    {
        collectedCoins++;
        ViewInGame.GetInstance().UpdateCoins();
    }

    public int GetCollectedCoins()
    {
        return collectedCoins;
    }
}
