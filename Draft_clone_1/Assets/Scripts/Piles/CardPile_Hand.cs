using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Hand : CardPile
{
    public new void Start()
    {
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 2f / 22f;
        m_PileHeightScreenFraction = 4f / 22f;
        m_PileWidthScreenFraction = 1f;
        base.Start();
    }

    protected override void addNewCardToPile(Button_Card cardToAdd)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3((Settings.ScreenSizeX / (2 * Settings.MaxCardsInHand)) + (Settings.ScreenSizeX * m_HeldCards.Count / Settings.MaxCardsInHand), transform.position.y, 12));
        m_HeldCards.Add(cardToAdd);
    }

    public override void ReturnCardToPlace(Button_Card cardToAdd)
    {
        int index = m_HeldCards.FindIndex(a => a.UniqueID == cardToAdd.UniqueID);
        

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3((Settings.ScreenSizeX / (2 * Settings.MaxCardsInHand)) + (Settings.ScreenSizeX * index / Settings.MaxCardsInHand), transform.position.y, 12));
    }

    protected override bool canCardEnter(Button_Card leavingCard)
    {
        bool output = true;

        if(m_HeldCards.Count >= 7)
        {
            output = false;
        }

        return output;
    }

    protected override bool canCardLeave(Button_Card leavingCard)
    {
        return true;
    }
}
