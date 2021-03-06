﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Discoverable[] discoverables;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var doEndGame = true;
        discoverables = FindObjectsOfType<Discoverable>();
        //Debug.Log("Discoverable count=" + discoverables.Length);
        foreach(Discoverable obj in discoverables) {
            try
            {


                if (obj.sentimentalItem != null && obj.sentimentalItem.name != "Nothing To See Here" && !obj.hasBeenDiscovered())
                {
                    //Debug.Log(obj.sentimentalItem.name + " not found on " + obj.gameObject.name);
                    doEndGame = false;
                    return;
                }
            }
            catch
            { }

        }

        if (doEndGame)
        {
            SceneController.instance.LoadNextScene();
            print("all items have been discovered");

        }
    }
}
