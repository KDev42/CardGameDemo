using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingField : MonoBehaviour
{
    [SerializeField] int sizeFieldX;
    [SerializeField] int sizeFieldY;
    [SerializeField] float sizeCell;
    [SerializeField] float space;

    public static PlayingField instance { get; private set; }

    public Cell[,] grid { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GetComponent<PlayingField>());
        }
    }

    private void Start()
    {
        GenerationGrid();
    }

    private void GenerationGrid()
    {
        grid = new Cell[sizeFieldX, sizeFieldY];
        int indexX, indexY;
        Transform currentChild;
        Cell currentCell;

        for(int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i);
            if (currentChild.GetComponent<GridPosition>())
            {
                indexX = CalculationIndex(currentChild.localPosition.x);
                indexY =-1* CalculationIndex(currentChild.localPosition.z);

                currentCell = new Cell();
                grid[indexX, indexY]= currentCell;
                currentChild.GetComponent<GridPosition>().coordinates = new GridCoordinates(indexX, indexY);

                if (currentChild.GetComponent<Tile>())
                {
                    currentCell.Tile = currentChild;
                }
            }
        }
    }

    private int CalculationIndex(float distance)
    {
        return (int)((distance - 0.5f * sizeCell) / (sizeCell + space));
    }
}
