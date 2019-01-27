﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoverable : MonoBehaviour
{
    public SentimentalItem sentimentalItem;

    protected bool isDiscovered = false;
    private ToastController toastController;

    // Start is called before the first frame update
    void Start()
    {
        toastController = FindObjectOfType<ToastController>();

        // If sentimentalItem not set, defaults to nothing to see here
        if (sentimentalItem == null)
        {
            GameObject nothingItemGO = GameObject.Find("Nothing To See Here");
            if (nothingItemGO != null)
                sentimentalItem = nothingItemGO.GetComponent<SentimentalItem>();
        }

    }

    public bool hasBeenDiscovered ()
    {
        return isDiscovered;
    }

    public virtual bool Discover()
    {
        bool isDegraded = false;
        Degradeable degradeable = gameObject.GetComponent<Degradeable>();
        if (degradeable != null)
        {
            isDegraded = degradeable.isDegraded;
        }

        if (isDiscovered || isDegraded)
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

            if (sentimentalItem.value > 0)
            {
                ScoreController.instance.ScoreItem(sentimentalItem);
            }

            if (toastController != null)
            {
                toastController.PublishToast(sentimentalItem);
            }

            //// change mesh state to reflect discovery, if meshes exist
            Transform closed = gameObject.transform.Find("closed");
            Transform opened = gameObject.transform.Find("opened");
            if (closed != null && opened != null)
            {
                closed.gameObject.SetActive(false);
                opened.gameObject.SetActive(true);
            }

            return true;
        }

    }
}
