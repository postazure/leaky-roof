using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour
{
    public bool active = true;
    public GameObject waterDrop;

    public float initialDripDelay = 0;

    [Range(0.01f, int.MaxValue)]
    public float secondsBetweenDrips = 1;

    private float lastDripTime;

    // Start is called before the first frame update
    void Start()
    {
        var delay = initialDripDelay + UnityEngine.Random.Range(0, 1f);
        lastDripTime = Time.fixedTime + delay;
    }

    void FixedUpdate()
    {
        float now = Time.fixedTime;
        bool shouldDrip = now - lastDripTime > secondsBetweenDrips;

        if (shouldDrip)
        {
            SpawnDrip();
            lastDripTime = now;
        }
    }

    private void SpawnDrip()
    {
        var newDrop = Instantiate<GameObject>(waterDrop, this.transform.position, Quaternion.identity);
    }
}
