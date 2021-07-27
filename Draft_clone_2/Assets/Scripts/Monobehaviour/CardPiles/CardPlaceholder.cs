using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlaceholder : MonoBehaviour
{
    private BoxCollider2D m_Collider;
    public EPileType PileType { get; set; }
    public int IndexInPile { get; set; }
    public Button_Card HeldCard { get; private set; }

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
        if(HeldCard != null)
        {
            Destroy(HeldCard.gameObject);
            HeldCard = null;
        }
    }

    public bool PlaceCard(Button_Card newButton)
    {
        bool output = false;

        if(HeldCard == null)
        {
            HeldCard = newButton;
            output = true;
        }

        return output;
    }
}
