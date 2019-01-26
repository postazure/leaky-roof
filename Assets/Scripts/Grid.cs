using System;
using UnityEngine;

public class Grid
{
    private Vector3 floorScale;

    public Grid(Vector3 floorScale)
    {
        this.floorScale = floorScale;
    }

    public Vector3 WorldPositionForGridCoords(Coords coords)
    {
        return new Vector3(coords.x - GetXOffset(), floorScale.y / 2f, coords.y - GetZOffset());
    }

    public Coords GridCoordsForWorldPosition(Vector3 position)
    {
        return new Coords((int)position.x + GetXOffset(), (int)position.z + GetZOffset());
    }

    private int GetZOffset()
    {
        return (int)(floorScale.z / 2);
    }

    private int GetXOffset()
    {
        return (int)(floorScale.x / 2);
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
