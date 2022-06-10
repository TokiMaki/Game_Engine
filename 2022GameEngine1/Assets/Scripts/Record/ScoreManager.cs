using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class ScoreManager : MonoBehaviour
{
    public int bestScore = 0;
    public int myScore = 0;

    public Text txtScore;

    public int getbest()
    {
        return bestScore;
    }
    public int getmy()
    {
        if (myScore >= bestScore)
        {
            bestScore = myScore;
        }
        return myScore;
    }
}