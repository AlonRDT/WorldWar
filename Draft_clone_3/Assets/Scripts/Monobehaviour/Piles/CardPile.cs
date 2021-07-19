using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile : MonoBehaviour
{
    protected float m_PileWidthScreenFraction;
    protected float m_PileHeightScreenFraction;
    protected float m_PileLocationXScreenFraction;
    protected float m_PileLocationYScreenFraction;

    public void TransferCard(Button_Card leavingCard, CardPile newCardHome)
    {
        if (canCardLeave(leavingCard) && newCardHome.canCardEnter(leavingCard))
        {
            newCardHome.addNewCardToPile(leavingCard);
        }
        else
        {
            ReturnCardToPlace(leavingCard);
        }
    }

    protected abstract bool canCardEnter(Button_Card enteringCard);
    protected abstract bool canCardLeave(Button_Card leavingCard);
    protected abstract void addNewCardToPile(Button_Card cardToAdd);
    public abstract void ReturnCardToPlace(Button_Card cardToReturn);

    public void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * m_PileLocationXScreenFraction, Screen.height * m_PileLocationYScreenFraction, 12));

        Vector2 screenSize;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(screenSize.x * 2 * m_PileWidthScreenFraction, screenSize.y * 2 * m_PileHeightScreenFraction);
    }
}
