using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Button_Static m_HoverButton;
    private Button_Static m_ActiveButton;
    private CardPlaceholder m_HoverPlaceholder;
    private CardPlaceholder m_ActivePlaceholder;

    private LineRenderer m_LineRenderer;
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private Vector3 m_MousePosition;
    private Camera m_MainCamera;

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
        if (m_ActivePlaceholder != null)
        {
            m_MousePosition = m_MainCamera.ScreenToWorldPoint(Input.mousePosition);
            m_StartPosition = m_ActivePlaceholder.transform.position;
            m_StartPosition.z = -(int)EZLocation.Line;
            m_LineRenderer.SetPosition(0, m_StartPosition);
            m_EndPosition = m_MousePosition;
            m_EndPosition.z = -(int)EZLocation.Line;
            m_LineRenderer.SetPosition(1, m_EndPosition);
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up, 0);
        if (hit.collider != null)
        {
            Button_Static button = hit.transform.GetComponent<Button_Static>();
            CardPlaceholder placeholder = hit.transform.GetComponent<CardPlaceholder>();
            if (button != null)
            {
                m_HoverButton = button;
            }
            else if (placeholder != null)
            {
                m_HoverPlaceholder = placeholder;
            }
        }
        
        if(m_ActiveButton != m_HoverButton)
        {
            m_ActiveButton = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (m_HoverButton != null)
            {
                m_ActiveButton = m_HoverButton;
            }
            else if (m_HoverPlaceholder != null)
            {
                m_ActivePlaceholder = m_HoverPlaceholder;
                m_LineRenderer.enabled = true; ;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (m_ActiveButton != null && m_ActiveButton == m_HoverButton)
            {
                m_ActiveButton.Click();
            }
            else if (m_ActivePlaceholder != null && m_ActivePlaceholder != m_HoverPlaceholder)
            {
                m_LineRenderer.enabled = false;
                PlayerNetwork.LocalPlayer.RequestMoveCard(m_ActivePlaceholder.PileType, m_ActivePlaceholder.IndexInPile, m_HoverPlaceholder.PileType, m_HoverPlaceholder.IndexInPile);
            }
            m_ActiveButton = null;
            m_ActivePlaceholder = null;

        }
    }
}
