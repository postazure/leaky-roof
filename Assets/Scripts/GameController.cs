using System.Collections;
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
        Debug.Log("Discoverable count=" + discoverables.Length);
        foreach(Discoverable obj in discoverables) {
            try
            {


                if (!obj.hasBeenDiscovered())
                {
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
