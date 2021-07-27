using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatText : MonoBehaviour
{
    protected float m_PileLocationXScreenFraction;
    protected float m_PileLocationYScreenFraction;
    protected Color m_TextColor;
    private TextMesh m_Text;

    // Start is called before the first frame update
    protected void Start()
    {
        transform.position = Settings.GetScreenLocation(m_PileLocationXScreenFraction, m_PileLocationYScreenFraction, (int)EZLocation.Pile);
        m_Text = GetComponent<TextMesh>();
        m_Text.color = m_TextColor;
    }

    public void HideText()
    {
        gameObject.SetActive(false);
    }

    public void ShowText()
    {
        gameObject.SetActive(true);
    }

    public void SetText(string input)
    {
        m_Text.text = input;
    }
}
