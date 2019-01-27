using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotalDisplayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int totalScore = ScoreController.instance.GetTotalScore();
        GetComponent<Text>().text = totalScore.ToString();
    }
}
