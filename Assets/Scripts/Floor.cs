using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject puddle;

    // Start is called before the first frame update
    void Start()
    {
        
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
            SpawnOrGrowPuddle(other.gameObject.transform.position);
            Destroy(other.gameObject);
        }
    }

    private void SpawnOrGrowPuddle(Vector3 position)
    {
        Debug.Log("Spawn puddle at " + position);
        Vector2 coords = Grid.GridCoordsForWorldPosition(position);
        SpawnPuddle(coords);
    }

    private void SpawnPuddle(Vector2 coords)
    {
        Vector3 puddlePosition = Grid.WorldPositionForGridCoords(coords, transform.localScale.y);
        Instantiate(puddle, puddlePosition, Quaternion.identity);
    }
}
