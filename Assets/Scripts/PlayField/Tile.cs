using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject outline;

    public TypeLists.Tile own;
    public float currentHeingh;

    private Animator animator;
    private Vector3 startingPosition;

    private void Start()
    {
        animator = transform.GetComponent<Animator>();
        startingPosition = transform.position;
    }

    private void Update()
    {
        transform.position = startingPosition + Vector3.up * currentHeingh;
    }

    private void OnMouseEnter()
    {
        animator.SetBool("f", true);
        EventManager.instance.CellSelected(transform);
    }

    private void OnMouseExit()
    {
        animator.SetBool("f", false);
        EventManager.instance.CellDeselected(transform);
    }

    public void SetActiveOutline(bool outlineIsActive)
    {
        outline.SetActive(outlineIsActive);
    }

    public void ActivationTile()
    {

    }

    public void DeactivationTile()
    {

    }
}
