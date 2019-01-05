using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    { gameState.PlayerScores[gameState.CurrentPlayerId] = gameState.CurrentScore;
        gameState.Players[gameState.CurrentPlayerId].HasThrownThisTurn = true;

        IsEndOfRound();
        if (gameState.IsEndOfRound)
        {
            findLoser(scoreManager.FindLowestScore(gameState.PlayerScores));
        }
        else
        {
            TurnReset();
            gameState.CurrentPlayerId = (gameState.CurrentPlayerId + 1) % gameState.Players.Count;
        }
        Debug.Log("######################");
        Debug.Log("End of round: " + gameState.IsEndOfRound);
        Debug.Log("Score Iris: " + gameState.PlayerScores[0]);
        Debug.Log("Iris heeft gegooid: " + gameState.Players[0].HasThrownThisTurn.ToString());

        Debug.Log("Score Mathijs: " + gameState.PlayerScores[1]);
        Debug.Log("Mathijs heeft gegooid: " + gameState.Players[1].HasThrownThisTurn.ToString());
        Debug.Log("Loser :  " + gameState.LoserPlayerId);
    }

    public void TurnReset()
    {
        gameState.CurrentScore = 0;
        gameState.DieScores = new int[gameState.Players.Count];
    }

    public void RoundReset()
    {
        TurnReset();
        gameState.PlayerScores =  new int[gameState.Players.Count];
        foreach (Player player in gameState.Players)
        {
            //player.HasThrownThisTurn = false;
        }
        gameState.LoserPlayerId = 0;
    }

    private void IsEndOfRound()
    {
        if (gameState.Players.Where(x => x.HasThrownThisTurn == false).Count() > 0)
        {
            gameState.IsEndOfRound = false;
        }
        gameState.IsEndOfRound = true;
    }

    private void findLoser(int lowestScore)
    {
        // This doesnt really work with ties yet.
        gameState.LoserPlayerId =  gameState.Players.First(player => player.CurrentScore == lowestScore).Id;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
