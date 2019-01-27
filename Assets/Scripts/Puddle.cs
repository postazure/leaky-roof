using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public float percentPerDrop = 0.1f;

    private float percentageFull;

    private void Update()
    {
        transform.localScale = new Vector3(percentageFull, transform.localScale.y, percentageFull);
    }

    internal void Increment()
    {
        percentageFull += percentPerDrop;
    }
}
