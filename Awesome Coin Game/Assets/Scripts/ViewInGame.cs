﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ViewInGame : MonoBehaviour
{
    public TMP_Text coinsLabel;
    public TMP_Text scoreText;
    public TMP_Text highestscoreText;

    private static ViewInGame sharedInstance;

    public static ViewInGame GetInstance()
    {
        return sharedInstance;
    }
    private void Awake()
    {
        sharedInstance = this;
    }
    private void Start()
    {
        
    }

    public void ShowHighestScore()
    {
        highestscoreText.text = PlayerController.GetInstance().GetMaxScore().ToString();
    }
    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.GetInstance().currentGameState == GameState.InGame)
        {
            
            scoreText.text = PlayerController.GetInstance().GetDistance().ToString();

        }
    }

    public void UpdateCoins()
    {
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
    }
}
