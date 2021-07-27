using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button_Card : GameButton
{
    public EPileType HoldingPileType { get; set; }
    public override void StartMouseHover()
    {
        transform.localScale = new Vector3(12, 12, 1);
    }

    //protected override void targetEnd()
    //{
    //    transform.localScale = new Vector3(10, 10, 10);
    //    if (m_FingerSlidOffButton)
    //    {
    //        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(transform.position), -Vector2.up, 0);
    //        if (hit.collider != null)
    //        {
    //            CardPile pile = hit.transform.GetComponent<CardPile>();
    //            if (pile == null || pile == m_CardHolder)
    //            {
    //                m_CardHolder.ReturnCardToPlace(this);
    //            }
    //            else
    //            {
    //                m_CardHolder.TransferCard(this, pile);
    //            }
    //        }
    //    }
    //}

    public override void StopMouseHover()
    {
        transform.localScale = new Vector3(10, 10, 1);
    }
}
