using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Use this for initialization
   
    public Text PlayerName;
    public Text ScoreLabel;
    public Text MessageLabel;
    private GameState gameState;
    
	void Start () {
        gameState = GameObject.FindObjectOfType<GameState>();
	}
	
	// Update is called once per frame
	void Update () {

        if(gameState.IsEndOfRound)
        {
            MessageLabel.text = gameState.Players[gameState.LoserPlayerId].Name + " is the loser!";
        }
        PlayerName.text = gameState.Players[gameState.CurrentPlayerId].Name;
        ScoreLabel.text = gameState.CurrentScore.ToString();
	}
}
