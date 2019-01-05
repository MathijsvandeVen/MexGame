using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int ThrowDie()
    {
        return Random.Range(1, 6);
    }

    public int CalculateMexScore(int[] dieScores)
    {
        // RULES:
        // The highest number thrown should be the tens (10,20,30 etc.),
        // while the lower number thrown should be the single (1,2,3, etc.).
        // Example: when 6 and 5 are thrown, the score should be 65. 
        // When 5 and 4 are thrown, the score should be 54.
        // When the thrown numbers are equal, make it in the hundreds
        // So double 1 should be 100, double 2 200 etc.
        int result;

        if (dieScores[0] > dieScores[1])
        {
            result = (dieScores[0] * 10) + dieScores[1];
        }
        else if (dieScores[0] < dieScores[1])
        {
            result = dieScores[0] + (dieScores[1] * 10);
        }
        else
        {
            result = (dieScores[0] * 100);
        }
        return result;
    }
}
