using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoverable : MonoBehaviour
{
    public int discoveryValue = 0;

    protected bool isDiscovered = false;
    private ToastController toastController;
    private ScoreController scoreController;

    // Start is called before the first frame update
    void Start()
    {
        toastController = FindObjectOfType<ToastController>();
        scoreController = FindObjectOfType<ScoreController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Discover()
    {
        if (isDiscovered)
        {
            if (toastController != null)
            {
                toastController.PublishToast("Nothing to discover");
            }
            return false;
        }
        else
        {
            isDiscovered = true;

            if (scoreController != null)
            {
                scoreController.IncrementScore(discoveryValue);
            }
            if (toastController != null)
            {
                toastController.PublishToast("+" + discoveryValue + " Sentiment");
            }
            return true;
        }

    }
}
