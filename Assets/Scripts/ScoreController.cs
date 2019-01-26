using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score = 0;

    public void IncrementScore(int value)
    {
        score += value;
    }
}
