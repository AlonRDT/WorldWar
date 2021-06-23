using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    private float m_MinimumLongPressTime;

    private float m_DisengageDistance;

    private float m_PressTime;

    protected bool m_FingerSlidOffButton;

    private Vector3 m_PressLocation;
    [SerializeField]
    public int UniqueID { get; set; }


    public void Update()
    {
        m_PressTime += Time.deltaTime;

        if (m_FingerSlidOffButton)
        {
            updateWhileDisengaged();
        }
        else
        {
            if (isDisengage())
            {
                disengaged();
            }
            else
            {
                updateWhileEngaged();
            }
        }
    }

    public void Start()
    {
        this.enabled = false;
        m_MinimumLongPressTime = 0.2f;
        m_DisengageDistance = 1;
    }

    public void Down()
    {
        m_PressTime = 0f;
        m_PressLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_FingerSlidOffButton = false;
        this.enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
        targetStart();
    }
    public void Up(bool activateClick)
    {
        this.enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        targetEnd();

        if (activateClick)
        {
            if (m_PressTime >= m_MinimumLongPressTime)
            {
                longClick();
            }
            else
            {
                shortClick();
            }
        }
    }

    private bool isDisengage()
    {
        bool result;

        if (m_FingerSlidOffButton)
        {
            result = false;
        }
        else if (Mathf.Abs((m_PressLocation - Camera.main.ScreenToWorldPoint(Input.mousePosition)).magnitude) > m_DisengageDistance)
        {
            result = true;
            m_FingerSlidOffButton = true;
        }
        else
        {
            result = false;
        }

        return result;
    }

    protected abstract void targetStart();

    protected abstract void shortClick();

    protected abstract void longClick();

    protected abstract void targetEnd();

    protected abstract void disengaged();

    protected abstract void updateWhileEngaged();

    protected abstract void updateWhileDisengaged();
}
