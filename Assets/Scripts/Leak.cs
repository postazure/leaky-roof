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
    public float secondsBetweenDrips = 2;

    [Range(0.01f, int.MaxValue)]
    public float speedUpPerSecond = 0.02f;

    private float lastDripTime;
    private float lastSpeedUpTime;

    // Start is called before the first frame update
    void Start()
    {
        var delay = initialDripDelay + UnityEngine.Random.Range(0, secondsBetweenDrips);
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

        bool shouldSpeedUp = now - lastSpeedUpTime > 1f;
        if (shouldSpeedUp)
        {
            secondsBetweenDrips -= speedUpPerSecond;
            secondsBetweenDrips = Math.Max(0.2f, secondsBetweenDrips);
            lastSpeedUpTime = now;
        }
    }

    private void SpawnDrip()
    {
        var newDrop = Instantiate<GameObject>(waterDrop, this.transform.position, Quaternion.identity);
    }
}
