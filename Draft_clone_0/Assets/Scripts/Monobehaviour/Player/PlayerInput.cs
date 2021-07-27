using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private GameButton m_HoverButton;
    private Button_Card m_TargetButton;
    private Button_Card m_TransitionButton;
    private CardPile m_HoverPile;
    private LineRenderer m_LineRenderer;
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private Vector3 m_MousePosition;
    private Camera m_MainCamera;
    public bool CanInteract { get; set; }

    private void OnLevelWasLoaded(int level)
    {
        m_MainCamera = Camera.main;
    }

    private void Start()
    {
        m_MainCamera = Camera.main;
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TransitionButton != null || CanInteract == false) return;

        if (m_TargetButton != null)
        {
            m_MousePosition = m_MainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        CardPile pile = null;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up, 0);
        if (hit.collider != null)
        {
            GameButton button = hit.transform.GetComponent<GameButton>();
            pile = hit.transform.GetComponent<CardPile>();
            if (button != null)
            {
                if (m_HoverButton != button)
                {
                    if (m_HoverButton != null)
                    {
                        m_HoverButton.StopMouseHover();
                    }
                    m_HoverButton = button;
                    m_HoverButton.StartMouseHover();
                    
                }
                Button_Card newButtonHover = m_HoverButton as Button_Card;
                if (newButtonHover != null)
                {
                    pile = CardPileManager.GetCardPile(newButtonHover.HoldingPileType);
                }
            }
            else
            {
                if (m_HoverButton != null)
                {
                    m_HoverButton.StopMouseHover();
                    m_HoverButton = null;
                }
            }
        }
        else
        {
            if (m_HoverButton != null)
            {
                m_HoverButton.StopMouseHover();
                m_HoverButton = null;
            }
        }

        if (m_TargetButton != null && m_HoverPile != pile)
        {
            if (m_HoverPile != null)
            {
                //m_HoverPile.StopPileHover();
            }
            if (pile != null)
            {
                //pile.StartPileHover(m_TargetButton);
            }
        }
        m_HoverPile = pile;

        if (Input.GetMouseButtonDown(0))
        {
            if (m_HoverButton != null)
            {
                m_TargetButton = m_HoverButton as Button_Card;
                if (m_TargetButton != null)
                {
                    m_LineRenderer.enabled = true;
                }
                else
                {
                    m_HoverButton.Click();
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (m_TargetButton != null)
            {
                m_StartPosition = m_TargetButton.transform.position;
                m_StartPosition.z = -(int)EZLocation.Line;
                m_LineRenderer.SetPosition(0, m_StartPosition);
                m_EndPosition = m_MousePosition;
                m_EndPosition.z = -(int)EZLocation.Line;
                m_LineRenderer.SetPosition(1, m_EndPosition);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (m_TargetButton != null)
            {
                m_LineRenderer.enabled = false;
                m_TransitionButton = m_TargetButton;
                Debug.Log(pile == null);
                if (m_HoverPile != null)
                {
                    //m_HoverPile.StopPileHover();
                    //CardPileManager.GetCardPile(m_TargetButton.HoldingPileType).TransferCard(m_TargetButton, m_HoverPile.PileType);
                }
                m_TargetButton = null;
            }
        }
    }

    public Button_Card GetAndResetTransitionCard()
    {
        Button_Card output = m_TransitionButton;
        m_TransitionButton = null;
        return output;
    }
}
