using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonsController : MonoBehaviour
{
    private static SingletonsController _instance;
    public static SingletonsController instance { get { return _instance; } }

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
}
