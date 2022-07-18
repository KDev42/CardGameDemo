using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] GameObject cartPref;
    [SerializeField] int quantituCard;

    private List<GameObject> cards =  new List<GameObject>();

    private void Start()
    {
        SpawnDeck();
        StartCoroutine(DelayOpen());
    }

    IEnumerator DelayOpen()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < quantituCard - 1; i++)
        {
            OpenCard(cards[i]);
            //yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnDeck()
    {
        for (int i = 0; i < quantituCard; i++)
        {
            cards.Add( Instantiate(cartPref, transform.position, transform.rotation,transform));
        }
    }

    private void OpenCard(GameObject card)
    {
        card.GetComponent<DisplayCard>().outsideOfHand = false;
        PlacementCards.instance.AddCard(card);
        EventManager.instance.ChangeCardsSlot();
    }
}
