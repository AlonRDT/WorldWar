using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Shop : CardPile
{
    public static CardPile_Shop Instance;
    private List<Button_Card> m_HeldCards;
    [SerializeField] GameObject m_MosnterPrefab;

    // Start is called before the first frame update
    public new void Start()
    {
        Instance = this;
        m_HeldCards = new List<Button_Card>();
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 18f / 22f;
        m_PileHeightScreenFraction = 8f / 22f;
        m_PileWidthScreenFraction = 1f;
        base.Start();
    }

    protected override void addNewCardToPile(Button_Card cardToAdd)
    {
        throw new System.NotImplementedException();
    }

    public override void ReturnCardToPlace(Button_Card cardToReturn)
    {
        int index = m_HeldCards.FindIndex(a => cardToReturn == a);
        int cardAmount = m_HeldCards.Count;
        float xFraction = (m_PileWidthScreenFraction / (cardAmount + 1)) * (index + 1);// + m_PileLocationXScreenFraction;
        cardToReturn.gameObject.transform.position = Settings.GetScreenLocation(xFraction, m_PileLocationYScreenFraction, (int)EZLocation.Card);
    }

    protected override bool canCardEnter(Button_Card enteringCard)
    {
        return true;
    }

    protected override bool canCardLeave(Button_Card leavingCard)
    {
        return true;
    }

    public void ReplaceCards(List<CardSlot> newCards)
    {
        foreach (var card in m_HeldCards)
        {
            Destroy(card);
        }
        
        foreach (var cardSlot in newCards)
        {
            
        }
        
    }

    public void DestroyCards()
    {
        foreach (var card in m_HeldCards)
        {
            Destroy(card);
        }
    }

    public void CreateNewCard(CardFinalData newCardData)
    {
        Button_Card_Monster newCard;
        newCard = Instantiate(m_MosnterPrefab, Vector3.zero, Quaternion.identity).GetComponent<Button_Card_Monster>();
        newCard.InitializeVisualInformation(newCardData);
        m_HeldCards.Add(newCard);
    }

    public void ArrangeCards()
    {
        foreach (var card in m_HeldCards)
        {
            ReturnCardToPlace(card);
        }
    }
}
