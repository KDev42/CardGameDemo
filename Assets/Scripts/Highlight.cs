using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public static Highlight instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GetComponent<Highlight>());
        }
    }

    public void OnHighlightObject(List<Transform> targets, TypeLists.Targets type)
    {
        if(TypeLists.Equals(TypeLists.Highlight.square,type))
        {
            OnTilesOutline(targets);
        }
        else if(TypeLists.Equals(TypeLists.Highlight.outline, type))
        {

        }
    }

    public void OffHighlightObject(List<Transform> targets, TypeLists.Targets type)
    {
        if (TypeLists.Equals(TypeLists.Highlight.square, type))
        {
            OffTilesOutline(targets);
        }
        else if (TypeLists.Equals(TypeLists.Highlight.outline, type))
        {

        }
    }

    private void OnTilesOutline(List<Transform> tiles) 
    {
        foreach(Transform tile in tiles)
        {
            tile.GetComponent<Tile>().SetActiveOutline(true);
        }
    }

    private void OffTilesOutline(List<Transform> tiles)
    {
        foreach(Transform tile in tiles)
        {
            tile.GetComponent<Tile>().SetActiveOutline(false);
        }
    }
}
