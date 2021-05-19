using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button_Card : Button
{
    private CardPile m_CardHolder;
    protected override void targetStart()
    {
        transform.localScale = new Vector3(12, 12, 12);
    }

    protected override void targetEnd()
    {
        transform.localScale = new Vector3(10, 10, 10);
        if (m_FingerSlidOffButton)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(transform.position), -Vector2.up, 0);
            if (hit.collider != null)
            {
                CardPile pile = hit.transform.GetComponent<CardPile>();
                if (pile == null || pile == m_CardHolder)
                {
                    m_CardHolder.ReturnCardToPlace(this);
                }
                else
                {
                    m_CardHolder.TransferCard(this, pile);
                }
            }
        }
    }

    protected override void disengaged()
    {

    }

    protected override void updateWhileDisengaged()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
    }

    protected override void updateWhileEngaged()
    {

    }
}
