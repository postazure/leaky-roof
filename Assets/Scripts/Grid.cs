using System;
using UnityEngine;

public abstract class Grid
{
    static public Vector3 WorldPositionForGridCoords(Vector2 coords, float floorHeight)
    {
        return new Vector3(coords.x, floorHeight / 2f, coords.y);
    }

    static public Vector2 GridCoordsForWorldPosition(Vector3 position)
    {
        return new Vector2(position.x, position.z);
    }
}
