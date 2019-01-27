using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public PuddleGroup puddleGroupPrefab;

    private PuddleGroup[,] puddleGroups;
    private Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(transform);

        int rows = (int) Math.Floor(transform.localScale.x);
        int cols = (int) Math.Floor(transform.localScale.z);
        puddleGroups = new PuddleGroup[rows, cols];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var waterDrop = other.gameObject.GetComponent<WaterDrop>();
        if (waterDrop)
        {
            EnsurePuddleGroupExistsAt(other.gameObject.transform.position);
            Destroy(other.gameObject);
        }
    }

    private void EnsurePuddleGroupExistsAt(Vector3 position)
    {
        //Debug.Log("Ensuring a puddle group is at " + position);

        Grid.Coords coords = grid.GridCoordsForWorldPosition(position);
        PuddleGroup puddleGroup = puddleGroups[coords.x, coords.y];
        if (puddleGroup)
        {
            //Debug.Log("Puddle group already at " + coords + ": " + puddlePercentage);
            if (puddleGroup.IsFull())
            {
                Grid.Coords adjacentCoords = puddleGroup.HeadCoords() + new Grid.Coords(1, 0);
                PuddleGroup adjacentGroup = SpawnPuddleGroup(adjacentCoords);
                puddleGroup.SetOverflowGroup(adjacentGroup);
            }
            puddleGroup.Increment();
        }
        else
        {
            //Debug.Log("Spawning new puddle group at " + coords);
            SpawnPuddleGroup(coords);
        }
    }

    private PuddleGroup SpawnPuddleGroup(Grid.Coords coords)
    {
        Vector3 puddlePosition = grid.WorldPositionForGridCoords(coords);

        PuddleGroup puddleGroup = Instantiate(puddleGroupPrefab, puddlePosition, Quaternion.identity);
        puddleGroup.Init(coords);
        puddleGroup.Increment();

        puddleGroups[coords.x, coords.y] = puddleGroup;

        return puddleGroup;
    }
}
