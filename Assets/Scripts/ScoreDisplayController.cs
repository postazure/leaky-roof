using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayController : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        string scoreString = ScoreController.instance.GetScoredItemsString();
        text = GetComponent<Text>();
        text.text = scoreString;
    }
}
