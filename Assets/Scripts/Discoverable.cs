using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoverable : MonoBehaviour
{
    private bool isDiscovered = false;
    public int discoveryValue = 0;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Discover()
    {
        if (isDiscovered)
        {
            return false;
        }
        else
        {
            isDiscovered = true;

            var scoreController = FindObjectOfType<ScoreController>();
            scoreController.IncrementScore(discoveryValue);
            
            return true;
        }

    }
}
