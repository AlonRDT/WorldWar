using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlaceholder : MonoBehaviour
{
    private BoxCollider2D m_Collider;
    public EPileType PileType { get; set; }
    public int IndexInPile { get; set; }
    private Button_Card m_HeldCard;

    // Start is called before the first frame update
    private void Awake()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    public void SetLocation(float xScreenFracture, float yScreenFracture)
    {
        transform.position = Settings.GetScreenLocation(xScreenFracture, yScreenFracture, (int)EZLocation.Placeholder);
    }

    public void SetColliderSize(float xScreenFracture, float yScreenFracture)
    {
        m_Collider.size = Settings.GetColliderSize(xScreenFracture, yScreenFracture);
    }

    public void DestroyCard()
    {
        if(m_HeldCard != null)
        {
            Destroy(m_HeldCard.gameObject);
            m_HeldCard = null;
        }
    }

    public bool PlaceCard(Button_Card newButton)
    {
        bool output = false;

        if(m_HeldCard == null)
        {
            m_HeldCard = newButton;
            m_HeldCard.transform.position = transform.position;
            output = true;
        }

        return output;
    }

    public Button_Card RemoveCard()
    {
        Button_Card output = m_HeldCard;
        m_HeldCard = null;
        return output;
    }
}
