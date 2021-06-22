using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ViewInGame : MonoBehaviour
{
    public TMP_Text coinsLabel;
    public TMP_Text scoreText;
    public TMP_Text highestscoreText;

    private void Start()
    {
        
    }

    void showHighestScore()
    {
        highestscoreText.text = PlayerController.GetInstance().GetMaxScore().ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetInstance().currentGameState == GameState.GameOver)
        {
            showHighestScore();
        }
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
        scoreText.text = PlayerController.GetInstance().GetDistance().ToString();
    }
}
