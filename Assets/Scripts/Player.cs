using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int Id { get; private set; }
    public string Name{ get; set; }
    public int CurrentScore { get; set; }
    public bool HasThrownThisTurn { get; set; }


    public Player(int id,  string name)
    {
        Id = id;
        Name = name;
    }
}
