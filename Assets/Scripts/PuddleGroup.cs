using System.Collections.Generic;
using UnityEngine;

public class PuddleGroup : MonoBehaviour
{
    public Puddle puddlePrefab;
    public float maxPuddleSplash = 0.25f;
    public int maxPuddleWater = 5;

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
        float amountOfWater = 0f;
        puddles.ForEach(p => amountOfWater += p.PercentageFull);
        return amountOfWater >= maxPuddleWater;
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

        List<Puddle> availablePuddles = puddles.FindAll(p => !p.IsFull());
        if (availablePuddles.Count == 0)
        {
            return AddPuddle(RandomPuddlePosition());
        }

        Puddle puddle = availablePuddles[Random.Range(0, availablePuddles.Count)];
        float percentChanceForNewPuddle = puddle.PercentageFull / 2f; // the fuller the puddle gets, the more likely it is to splash and create a new one
        if (Random.Range(0f, 1f) <= percentChanceForNewPuddle)
        {
            return AddPuddle(RandomPuddlePosition());
        }

        return puddle;
    }

    internal Grid.Coords HeadCoords()
    {
        return overflowGroup ? overflowGroup.HeadCoords() : coords;
    }

    private Vector3 RandomPuddlePosition()
    {
        return new Vector3(RandomPuddleSplash(), 0, RandomPuddleSplash());
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
