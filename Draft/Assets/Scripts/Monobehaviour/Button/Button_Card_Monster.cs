using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Card_Monster : Button_Card
{
    [SerializeField] private TextMesh m_HealthText;
    [SerializeField] private TextMesh m_AttackText;
    [SerializeField] private TextMesh m_IncomeText;
    [SerializeField] private TextMesh m_DiplomacyText;

    public void InitializeVisualInformation(CardFinalData cardData)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardData.ImageLocation);
        //GetComponent<SpriteRenderer>().size = new Vector2(2, 2);
        m_HealthText.text = cardData.Health.ToString();
        m_AttackText.text = cardData.Attack.ToString();
        m_IncomeText.text = cardData.Income.ToString();
        m_DiplomacyText.text = cardData.DiplomacyPoints.ToString();
    }

    protected override void longClick()
    {
        Debug.Log("Long Click");
    }

    protected override void shortClick()
    {
        Debug.Log("Short Click");
    }
}
