using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die {

	public int AmountOfSides { get; private set; }
    public bool ShouldBeheld { get; set; }

    public Die(int amountOfSides)
    {
        AmountOfSides = amountOfSides;
    }
}
