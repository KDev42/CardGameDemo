using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeLists
{
   public enum Tile
   {
        player,
        enemy,
        neutral
   }

    public enum Cell
    {
        nullCell,
        emptyPlayer,
        emptyEnemy,
        unitPlayer,
        unitEnemy,
        city,
        neutral
    }

    public enum Targets
    {
        cellPlayer,
        unitPlayer,
        unitEnemy,
        city,
        cellEverything
    }

    public enum Highlight
    {
        outline,
        square
    }

    private static Dictionary<Targets, List<Cell>> CellToTarget = new Dictionary<Targets, List<Cell>>()
    {
        { Targets.cellPlayer, new List<Cell>{ Cell.emptyPlayer} },
        { Targets.unitPlayer, new List<Cell>{ Cell.unitPlayer} },
        { Targets.unitEnemy, new List<Cell>{Cell.unitEnemy } },
        { Targets.city, new List<Cell>{Cell.city } },
        { Targets.cellEverything, new List<Cell>{Cell.emptyEnemy, Cell.emptyPlayer, Cell.neutral } }
    };

    private static Dictionary<Highlight, List<Targets>> TargetToHighlight = new Dictionary<Highlight, List<Targets>>()
    {
        {Highlight.outline, new List<Targets> {Targets.unitPlayer, Targets.unitEnemy,Targets.city}},
        {Highlight.square, new List<Targets> {Targets.cellPlayer}}
    };

    public static bool Equals(Targets typeTargets,Cell typeCell)
    {
        List<int> targetsIndex = new List<int>();
        foreach (Targets target in CellToTarget[typeTargets])
            targetsIndex.Add((int)target);

        return FindMatches((int)typeCell, targetsIndex);
    }

    public static bool Equals(Highlight highlight, Targets targets)
    {
        List<int> targetsIndex = new List<int>();
        foreach (Targets target in TargetToHighlight[highlight])
            targetsIndex.Add((int)target);

        return FindMatches((int)targets, targetsIndex);
    }

    private static bool FindMatches(int compareWith, List<int> searchAmong)
    {
        foreach(int i in searchAmong)
        {
            if (i == compareWith)
                return true;
        }    

        return false;
    }
}
