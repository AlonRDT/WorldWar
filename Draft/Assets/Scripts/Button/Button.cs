using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    [SerializeField]
    public GameObject thisObject;

    [SerializeField]
    private float minimumLongPressTime;

    private float pressTime;

    private bool fingerSlidOffButton;

    private bool lastUpdateFingerSlidOffButton;


    public void Update()
    {
        pressTime += Time.deltaTime;
        if (fingerSlidOffButton && !lastUpdateFingerSlidOffButton)
        {
            disengaged();
        }
        lastUpdateFingerSlidOffButton = fingerSlidOffButton;

        if (fingerSlidOffButton)
        {
            updateWhileDisengaged();
        }
        else
        {
            updateWhileEngaged();
        }
    }

    public void Start()
    {
        this.enabled = false;
        minimumLongPressTime = 0.3f;
    }

    public void Down()
    {
        pressTime = 0f;
        fingerSlidOffButton = false;
        lastUpdateFingerSlidOffButton = false;
        this.enabled = true;
        targetStart();
    }
    public void Up(bool activateClick)
    {
        this.enabled = false;
        targetEnd();

        if (activateClick)
        {
            Debug.Log(minimumLongPressTime);
            if (pressTime >= minimumLongPressTime)
            {
                longClick();
            }
            else
            {
                shortClick();
            }
        }
    }

    protected abstract void targetStart();

    protected abstract void shortClick();

    protected abstract void longClick();

    protected abstract void targetEnd();

    protected abstract void disengaged();

    protected abstract void updateWhileEngaged();

    protected abstract void updateWhileDisengaged();
}
