using System;
using UnityEngine;

public class Grid
{
    private Transform floorTransform;

    public Grid(Transform floorTransform)
    {
        this.floorTransform = floorTransform;
    }

    public Vector3 WorldPositionForGridCoords(Coords coords)
    {
        float x = coords.x - GetXOffset();
        float y = floorTransform.position.y + floorTransform.localScale.y / 2f;
        float z = coords.y - GetZOffset();
        return new Vector3(x, y, z);
    }

    public Coords GridCoordsForWorldPosition(Vector3 position)
    {
        return new Coords((int)position.x + GetXOffset(), (int)position.z + GetZOffset());
    }

    private int GetZOffset()
    {
        return (int)(floorTransform.localScale.z / 2);
    }

    private int GetXOffset()
    {
        return (int)(floorTransform.localScale.x / 2);
    }

    public struct Coords
    {
        public int x, y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "[" + x + "][" + y + "]";
        }
    }
}
