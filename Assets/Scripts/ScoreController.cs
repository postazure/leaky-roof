using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    private static ScoreController _instance;
    public static ScoreController instance { get { return _instance; } }
    private List<SentimentalItem> foundItems = new List<SentimentalItem>();

    private void Awake()
    {
        // Singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

    }

    public void ScoreItem(SentimentalItem item)
    {
        print("Scored an item: " + item.name);
        foundItems.Add(item);
    }

    public string GetScoredItemsString()
    {
        string scoredItemsString = "";
        foundItems.ForEach((SentimentalItem obj) => { scoredItemsString += obj.description + "..." + obj.value + "\n"; });

        return scoredItemsString;
    }

    public int GetTotalScore()
    {
        int score = 0;
        foundItems.ForEach((SentimentalItem obj) => { score += obj.value; });

        return score;
    }
}
