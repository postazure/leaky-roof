using System.Collections.Generic;
using UnityEngine;

public class PuddleGroup : MonoBehaviour
{
    public Puddle puddlePrefab;
    public float maxPuddleSplash = 0.25f;
    public int maxPuddles = 5;

    private Grid.Coords coords;
    private List<Puddle> puddles = new List<Puddle>();
    private PuddleGroup overflowGroup;

    public void Init(Grid.Coords coords)
    {
        this.coords = coords; 
    }

    public void Increment()
    {
        Puddle puddle;

        if (puddles.Count == 0)
        {
            puddle = AddPuddle(Vector3.zero);
        }
        else
        {
            puddle = FindOrAddPuddle();
        }

        puddle.Increment();
    }

    public bool IsFull()
    {
        return IsThisGroupFull() && IsOverflowGroupFull();
    }

    public void SetOverflowGroup(PuddleGroup puddleGroup)
    {
        if (this.overflowGroup)
        {
            this.overflowGroup.SetOverflowGroup(puddleGroup);
        }
        else
        {
            this.overflowGroup = puddleGroup;
        }
    }

    private bool IsThisGroupFull()
    {
        return puddles.Count >= maxPuddles && puddles.TrueForAll(p => p.IsFull());
    }

    private bool IsOverflowGroupFull()
    {
        return overflowGroup == null || overflowGroup.IsFull();
    }

    private Puddle FindOrAddPuddle()
    {
        if (IsThisGroupFull() && overflowGroup)
        {
            return overflowGroup.FindOrAddPuddle();
        }

        Puddle puddle = puddles.Find(p => !p.IsFull());
        if (!puddle)
        {
            Vector3 position = new Vector3(RandomPuddleSplash(), 0, RandomPuddleSplash());
            puddle = AddPuddle(position);
        }

        return puddle;
    }

    internal Grid.Coords HeadCoords()
    {
        return overflowGroup ? overflowGroup.HeadCoords() : coords;
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
