using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState gameState;
    private ScoreManager scoreManager;
    
    // Use this for initialization
    void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

        gameState.Players = new List<Player>();

        string[] PlayerNames = { "Iris", "Mathijs" };

        for (int i = 0; i < PlayerNames.Length; i++)
        {
            gameState.Players.Add(new Player(i, PlayerNames[i]));
        }

        gameState.DieScores = new int[2];
        //DiesToBeHeld = new bool[2];
        gameState.PlayerScores = new int[gameState.Players.Count];
    }

    public void ThrowDice()
    {
        for (int i = 0; i < gameState.DieScores.Length; i++)
        {
            gameState.DieScores[i] = scoreManager.ThrowDie();
        }
        gameState.CurrentScore = scoreManager.CalculateMexScore(gameState.DieScores);
    }

    public void EndTurn()
    {
        gameState.PlayerScores[gameState.CurrentPlayerId] = gameState.CurrentScore;

        TurnReset();
        gameState.CurrentPlayerId = (gameState.CurrentPlayerId + 1) % gameState.Players.Count;
    }

    public void TurnReset()
    {
        gameState.CurrentScore = 0;
        gameState.PlayerScores = new int[gameState.Players.Count];
    }
    
   
    // Update is called once per frame
    void Update()
    {
    }
}
