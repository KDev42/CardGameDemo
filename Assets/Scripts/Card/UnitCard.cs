using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCard : MonoBehaviour,IApplicable
{
    [SerializeField] GameObject spawnObject;

    public void Apply(Transform target)
    {
        GridCoordinates gridCoordinates = target.GetComponent<GridPosition>().coordinates;
        Cell cell = PlayingField.instance.grid[gridCoordinates.x, gridCoordinates.y];

        Transform unit = Instantiate(spawnObject.transform, target.position, target.rotation);
        cell.Unit = unit;
        cell.type = TypeLists.Cell.unitPlayer;
        Debug.Log("Its___Work");
    }

    public bool CanApplay(Transform target)
    {
        GridCoordinates gridCoordinates = target.GetComponent<GridPosition>().coordinates;
        Cell cell = PlayingField.instance.grid[gridCoordinates.x, gridCoordinates.y];

        if (TypeLists.Equals(GetComponent<Card>().target,cell.type))
        {
            return true;
        }

        return false;
    }
}
