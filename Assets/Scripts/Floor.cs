using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject puddle;

    private float[,] puddlePercentages;
    private Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(transform);

        int rows = (int) Math.Floor(transform.localScale.x);
        int cols = (int) Math.Floor(transform.localScale.z);
        puddlePercentages = new float[rows, cols];
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
            EnsurePuddleExistsAt(other.gameObject.transform.position);
            Destroy(other.gameObject);
        }
    }

    private void EnsurePuddleExistsAt(Vector3 position)
    {
        //Debug.Log("Ensuring a puddle is at " + position);

        Grid.Coords coords = grid.GridCoordsForWorldPosition(position);
        float puddlePercentage = puddlePercentages[coords.x, coords.y];
        if (puddlePercentage > 0)
        {
            //Debug.Log("Puddle already at " + coords + ": " + puddlePercentage);
        }
        else
        {
            //Debug.Log("Spawning new puddle at " + coords);
            SpawnPuddle(coords);
        }
    }

    private void SpawnPuddle(Grid.Coords coords)
    {
        Vector3 puddlePosition = grid.WorldPositionForGridCoords(coords);
        Instantiate(puddle, puddlePosition, Quaternion.identity);

        puddlePercentages[coords.x, coords.y] += 0.0001f;
    }
}
