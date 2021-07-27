using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button_Static : GameButton
{
    protected float m_PileWidthScreenFraction;
    protected float m_PileHeightScreenFraction;
    protected float m_PileLocationXScreenFraction;
    protected float m_PileLocationYScreenFraction;

    // Start is called before the first frame update
    protected void Start()
    {
        transform.position = Settings.GetScreenLocation(m_PileLocationXScreenFraction, m_PileLocationYScreenFraction, (int)EZLocation.Pile);
        gameObject.GetComponent<BoxCollider2D>().size = Settings.GetColliderSize(m_PileWidthScreenFraction / transform.localScale.x, m_PileHeightScreenFraction / transform.localScale.y);
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }

    public void ShowButton()
    {
        gameObject.SetActive(true);
    }
}
