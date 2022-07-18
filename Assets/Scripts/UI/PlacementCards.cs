using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCards : MonoBehaviour
{
    [SerializeField] float widthCard;
    [SerializeField] float spasing;

    public static PlacementCards instance { get; private set; }

    private List<GameObject> activeCards;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GetComponent<PlacementCards>());
        }
        activeCards = new List<GameObject>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.GetComponent<Card>())
        {
            collision.transform.GetComponent<DisplayCard>().outsideOfHand = true; 
            //collision.transform.GetComponent<DisplayCard>().slotPosition = transform.position + Vector3.right * (transform.GetComponent<RectTransform>().rect.width / 2);
            RemoveCard(collision.gameObject);
            EventManager.instance.ChangeCardsSlot();
        }
    }

    public void AddCard(GameObject card)
    {
        activeCards.Add(card);
        card.transform.parent = transform;
        //ReplaceCards();
    }

    public void RemoveCard(GameObject card)
    {
        activeCards.Remove(card);
        //ReplaceCards();
    }

    public Vector3 CalculationPosition(GameObject card)
    {
        Vector3 position;
        float needfulSpace = widthCard + spasing;
        float existSpace = transform.GetComponent<RectTransform>().rect.width / activeCards.Count;

        Vector3 startingPoint = transform.position + Vector3.right * (transform.GetComponent<RectTransform>().rect.width / 2);

        int index = activeCards.IndexOf(card);

        if (existSpace > needfulSpace)
        {
            position = startingPoint - Vector3.right * (widthCard * (0.5f + index) + spasing * (index + 1));
        }
        else
        {
            position = startingPoint - Vector3.right * existSpace * (0.5f + index);
        }

        return position;
    }
}
