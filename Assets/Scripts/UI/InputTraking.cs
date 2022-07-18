using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTraking : MonoBehaviour
{
    [SerializeField] LayerMask cardLayer;
    [SerializeField] LayerMask tileLayer;

    private RaycastHit2D hit;
    private RaycastHit hitTile;
    private Card selectedCard;

    private enum STATES
    {
        cardSelected,
        cardNotSelected
    }

    private STATES state;

    private void Start()
    {
        state = STATES.cardNotSelected;
    }

    private void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if(Physics.Raycast(ray,out hitTile,1000,tileLayer))
        //{
        //    Debug.Log("Work" + hitTile.transform.name);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Input.mousePosition, Vector3.forward, 10, cardLayer);
            if (hit)
            {
                selectedCard = hit.transform.GetComponent<Card>();
                state = STATES.cardSelected;
                selectedCard.TakeCard();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(state == STATES.cardSelected)
            {
                state = STATES.cardNotSelected;
                selectedCard.ReleaseCard();
            }
        }
    }
}
