using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    [SerializeField] float speedCard;
    [SerializeField] float speedCardToSlot;
    [Range(0.1f, 1)] [SerializeField] float alfaCard;

    public bool outsideOfHand { get; set; } = true;

    private float startTime;
    private float journeyLength;
    private Vector3 startPosition;
    private Vector3 slotPosition;
    private bool cardIsTiedCursor;
    private Color cardColor;

    private enum States
    {
        idle,
        moveToCursor,
        moveToSlote
    }

    private States state = States.idle;

    private void Update()
    {
        if (state == States.moveToCursor)
        {
            if ((Input.mousePosition - transform.position).magnitude > 0.1 && !cardIsTiedCursor)
            {
                transform.position += (Input.mousePosition - transform.position) * speedCard * Time.deltaTime;
            }
            else
            {
                cardIsTiedCursor = true;
                transform.position = Input.mousePosition;
            }
        }

        if (state == States.moveToSlote)
        {
            if ((slotPosition - transform.position).magnitude > 0.1)
            {
                float distCovered = (Time.time - startTime) * speedCardToSlot;
                float fractionOfJourney = distCovered / journeyLength;

                transform.position = Vector2.Lerp(startPosition, slotPosition, fractionOfJourney);
                //transform.position += (slotPosition - transform.position) * speedCard * Time.deltaTime;
            }
            else
            {
                state = States.idle;
            }
        }
    }

    private void OnEnable()
    {
        EventManager.instance.changeCardsSlot += MoveToSlot;
    }

    private void OnDisable()
    {
        EventManager.instance.changeCardsSlot -= MoveToSlot;
    }

    public void Applay()
    {
        state = States.idle;
        GetComponent<Animator>().SetBool("decrease", true);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void MoveToCursor()
    {
        slotPosition = transform.position;
        ChangeCardAlfa(alfaCard);
        cardIsTiedCursor = false;
        state = States.moveToCursor;
    }

    private void MoveToSlot()
    {
        if (!outsideOfHand)
        {
            ChangeCardAlfa(1);

            slotPosition = PlacementCards.instance.CalculationPosition(gameObject);

            startTime = Time.time;
            startPosition = transform.position;
            journeyLength = (transform.position - slotPosition).magnitude;

            state = States.moveToSlote;
        }
    }

    private void ChangeCardAlfa(float alfa)
    {
        cardColor = transform.GetComponent<Image>().color;
        cardColor.a = alfa;
        transform.GetComponent<Image>().color = cardColor;
    }
}
