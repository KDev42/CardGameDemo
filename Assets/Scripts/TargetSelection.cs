using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelection : MonoBehaviour
{
    public static TargetSelection instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GetComponent<TargetSelection>());
        }
    }

    public List<Transform> SelectTargetCard(TypeLists.Targets condition)
    {
        List<Transform> targets = new List<Transform>();
        Transform target;

        foreach (Cell cell in PlayingField.instance.grid)
        {
            target = GetTarget(condition, cell);
            if (target !=null)
                targets.Add(target);
        }

        return targets;
    }

    private Transform GetTarget(TypeLists.Targets condition, Cell cell)
    {
        switch (condition)
        {
            case TypeLists.Targets.cellPlayer:
                if (cell.type == TypeLists.Cell.emptyPlayer)
                    return cell.Tile;
                break;
            case TypeLists.Targets.unitEnemy:
                if (cell.type == TypeLists.Cell.unitEnemy)
                    return cell.Unit;
                break;
            case TypeLists.Targets.unitPlayer:
                if (cell.type == TypeLists.Cell.unitPlayer)
                    return cell.Unit;
                break;
            case TypeLists.Targets.city:
                if (cell.type == TypeLists.Cell.city)
                    return cell.Unit;
                break;
        }

        return null;
    }
}
