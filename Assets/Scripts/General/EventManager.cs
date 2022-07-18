using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager instance { get; private set; }


    //public Action<Transform> cellSelected;
    //public Action<Transform> cellDeselected;

    public delegate void Action(Transform t);
    public delegate void SimpleAction();
    public event Action cellSelected;
    public event Action cellDeselected;
    public event SimpleAction changeCardsSlot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GetComponent<EventManager>());
        }
    }

    public void CellSelected(Transform tile)
    {
        if(cellSelected!=null)
            cellSelected(tile);
    }

    public void CellDeselected(Transform tile)
    {
        if (cellDeselected != null)
            cellDeselected(tile);
    }

    public void ChangeCardsSlot()
    {
        if (changeCardsSlot != null)
            changeCardsSlot();
    }
}
