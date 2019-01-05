using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public List<Player> Players;
    public int CurrentPlayerId = 0;

    public int[] DieScores;
    public int CurrentScore;
    //public bool[] DiesToBeHeld;

    public int[] PlayerScores;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
