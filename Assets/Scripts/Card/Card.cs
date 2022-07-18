using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TypeLists.Targets target;

    private List<Transform> targets;
    private Transform currentTarget;

    public void TakeCard()
    {
        transform.GetComponent<DisplayCard>().MoveToCursor();

        EventManager.instance.cellSelected += SelectedTarget;
        EventManager.instance.cellDeselected += DeselectedTarget;

        targets = new List<Transform>();
        targets = TargetSelection.instance.SelectTargetCard(target);
        Highlight.instance.OnHighlightObject(targets, target);
    }

    public void ReleaseCard()
    {
        EventManager.instance.cellSelected -= SelectedTarget;
        EventManager.instance.cellDeselected -= DeselectedTarget;

        Highlight.instance.OffHighlightObject(targets, target);

        if (currentTarget!=null && transform.GetComponent<IApplicable>().CanApplay(currentTarget))
        {
            transform.GetComponent<IApplicable>().Apply(currentTarget);
            GetComponent<DisplayCard>().Applay();
        }
        else
        {
            if(transform.GetComponent<DisplayCard>().outsideOfHand)
                PlacementCards.instance.AddCard(gameObject);
            transform.GetComponent<DisplayCard>().outsideOfHand = false;
            EventManager.instance.ChangeCardsSlot();
            //transform.GetComponent<DisplayCard>().MoveToSlot();
        }
    }

    private void SelectedTarget(Transform target)
    {
        currentTarget = target;
    }

    private void DeselectedTarget(Transform target)
    {
        if(target == currentTarget)
        {
            currentTarget = null;    
        }
    }
}
