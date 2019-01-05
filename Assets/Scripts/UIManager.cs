using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Use this for initialization
   
    public Text PlayerName;
    public Text ScoreLabel;
    private GameState gameState;
    
	void Start () {
        gameState = GameObject.FindObjectOfType<GameState>();
	}
	
	// Update is called once per frame
	void Update () {

        PlayerName.text = gameState.Players[gameState.CurrentPlayerId].Name;
        ScoreLabel.text = gameState.CurrentScore.ToString();
	}
}
