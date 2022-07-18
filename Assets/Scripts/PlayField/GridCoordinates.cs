using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GridCoordinates
{
    public int x;
    public int y;

    public GridCoordinates(int coordinateX, int coordinateY)
    {
        x = coordinateX;
        y = coordinateY;
    }
}
