using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public float percentPerDrop = 0.1f;

    private float percentageFull;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        transform.localScale = new Vector3(initialScale.x * percentageFull, initialScale.y, initialScale.z * percentageFull);
    }

    internal void Increment()
    {
        percentageFull += percentPerDrop;
        percentageFull = Math.Min(1, percentageFull);
    }

    public bool IsFull()
    {
        return percentageFull >= 1;
    }
}
