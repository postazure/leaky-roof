using System.Collections.Generic;
using UnityEngine;

public class PuddleGroup : MonoBehaviour
{
    public Puddle puddlePrefab;
    public float maxPuddleSplash = 0.25f;

    private List<Puddle> puddles = new List<Puddle>();

    public void Increment()
    {
        Puddle puddle;

        if (puddles.Count == 0)
        {
            puddle = AddPuddle(Vector3.zero);
        }
        else
        {
            puddle = IncrementOrAddPuddle();
        }

        puddle.Increment();
    }

    private Puddle IncrementOrAddPuddle()
    {
        Puddle puddle = puddles.Find(p => !p.IsFull());
        if (!puddle)
        {
            Vector3 position = new Vector3(RandomPuddleSplash(), 0, RandomPuddleSplash());
            puddle = AddPuddle(position);
        }

        return puddle;
    }

    private float RandomPuddleSplash()
    {
        return Random.Range(-maxPuddleSplash, maxPuddleSplash);
    }

    private Puddle AddPuddle(Vector3 position)
    {
        position.y = FindObjectsOfType<Puddle>().Length * 0.0001f; // Hax: prevent weird color highlight when puddles overlap

        Puddle puddle = Instantiate(puddlePrefab);
        puddle.transform.parent = gameObject.transform;
        puddle.transform.localPosition = position;
        puddles.Add(puddle);
        return puddle;
    }
}
