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
        }
        else
        {
            Destroy(this);
        }

    }

    public void ScoreItem(SentimentalItem item)
    {
        foundItems.Add(item);
    }

    public string GetScoredItemsString()
    {
        if(foundItems.Count == 0) return "You got nothing.";

        string scoredItemsString = "";

        foundItems.ForEach((SentimentalItem obj) => { scoredItemsString += Display(obj.name, obj.value.ToString()) + "\n"; });

        return scoredItemsString;
    }

    public int GetTotalScore()
    {
        int score = 0;
        foundItems.ForEach((SentimentalItem obj) => { score += obj.value; });

        return score;
    }

    public int FoundItemCount()
    {
        return foundItems.Count;
    }

    private string Display(string objName, string value)
    {
        int length = 40 - objName.Length + value.Length;
        string dots = "";
        for (int i = 0; i < length; i++)
        {
            dots += ".";
        }
        return objName + dots + value;
    }
}
