using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleGroup : MonoBehaviour
{
    public Puddle puddlePrefab;

    private List<Puddle> puddles = new List<Puddle>();

    public void Increment()
    {
        Puddle puddle = puddles.Find(p => !p.IsFull());
        if (!puddle)
        {
            puddle = Instantiate(puddlePrefab);
            puddle.transform.parent = gameObject.transform;
            puddle.transform.localPosition = Vector3.zero;
            puddles.Add(puddle);
        }

        puddle.Increment();
    }
}
