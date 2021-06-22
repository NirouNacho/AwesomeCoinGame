using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOverView : MonoBehaviour
{

    public TMP_Text coinsLabel;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetInstance().currentGameState ==GameState.GameOver)
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
        scoreText.text = PlayerController.GetInstance().GetDistance().ToString();

    }
}
