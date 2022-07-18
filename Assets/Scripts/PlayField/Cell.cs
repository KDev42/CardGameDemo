using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Cell : MonoBehaviour
{
    public TypeLists.Cell type;
    private Transform tile;
    private Transform unit;

    public Transform Tile
    {
        get 
        {
            return tile;    
        }
        set
        {
            tile = value;
            SetTile(tile);
        }

    }
    public Transform Unit
    {
        get
        {
            return unit;
        }
        set
        {
            unit = value;
            if (tile != null)
            {
                unit.SetParent(tile);
            }
        }

    }

    public Cell()
    {
        type = TypeLists.Cell.nullCell;
        tile = null;
        unit = null;
    }


    private void SetTile(Transform tile)
    {
        if (unit != null)
        {
            unit.SetParent(tile);
        }
        else
        {
            switch (tile.GetComponent<Tile>().own)
            {
                case TypeLists.Tile.neutral:
                    type = TypeLists.Cell.neutral;
                    break;
                case TypeLists.Tile.enemy:
                    type = TypeLists.Cell.emptyEnemy;
                    break;
                case TypeLists.Tile.player:
                    type = TypeLists.Cell.emptyPlayer;
                    break;
            }
        }
    }
}
