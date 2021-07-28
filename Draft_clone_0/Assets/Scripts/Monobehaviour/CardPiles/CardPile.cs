using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile : MonoBehaviour
{
    [SerializeField] private EPileType m_PileType;
    public EPileType PileType { get => m_PileType; private set => m_PileType = value; }
    protected CardPlaceholder[] m_CardPlaceholders;
    protected bool m_IsInitializePlaceholders;
    protected bool m_IsInitializePlaceholdersFromTop;
    protected int m_ArrayRowSize;
    protected int m_ArrayColumnSize;
    protected float m_PileWidthScreenFraction;
    protected float m_PileHeightScreenFraction;
    protected float m_PileLocationXScreenFraction;
    protected float m_PileLocationYScreenFraction;

    public Button_Card RemoveCard(int index)
    {
        return m_CardPlaceholders[index].RemoveCard();
    }

    public void PlaceCard(Button_Card newCard, int index)
    {
        m_CardPlaceholders[index].PlaceCard(newCard);
    }

    public void DestroyAllCards()
    {
        for (int i = 0; i < m_CardPlaceholders.Length; i++)
        {
            m_CardPlaceholders[i].DestroyCard();
        }
    }

    public void DestroyTargetCard(int index)
    {
        m_CardPlaceholders[index].DestroyCard();
    }

    public void Start()
    {
        CardPileManager.RegisterPile(this, m_PileType);
        m_CardPlaceholders = new CardPlaceholder[m_ArrayRowSize * m_ArrayColumnSize];

        for (int i = 0; i < m_CardPlaceholders.Length; i++)
        {
            //Debug.Log(Factory.Instance == null);
            m_CardPlaceholders[i] = Factory.Instance.GenerateCardPlaceholder(PileType, i);
            m_CardPlaceholders[i].transform.parent = transform;
            if(m_IsInitializePlaceholders == true)
            {
                placeCardPlaceholder(i, m_ArrayRowSize, m_ArrayColumnSize);
            }
        }
    }

    protected void placeCardPlaceholder(int placeholderIndex, int rowAmount, int columnAmount)
    {
        float startX = m_PileLocationXScreenFraction - (m_PileWidthScreenFraction / 2);
        float halfPlaceholderWidth = m_PileWidthScreenFraction == 0 ? 0 : (m_PileWidthScreenFraction / columnAmount) / 2;
        float startY = m_PileLocationYScreenFraction - (m_PileHeightScreenFraction / 2);
        float halfPlaceholderHeight = m_PileHeightScreenFraction == 0 ? 0 : (m_PileHeightScreenFraction / rowAmount) / 2;

        int yIndex = m_IsInitializePlaceholdersFromTop ? ((rowAmount - 1) - placeholderIndex / columnAmount) : placeholderIndex / columnAmount;

        float placeholderLocationXScreenFraction = startX + halfPlaceholderWidth + halfPlaceholderWidth * 2 * (placeholderIndex % columnAmount);
        float placeholderLocationYScreenFraction = startY + halfPlaceholderHeight + halfPlaceholderHeight * 2 * yIndex;

        m_CardPlaceholders[placeholderIndex].SetLocation(placeholderLocationXScreenFraction, placeholderLocationYScreenFraction);
        m_CardPlaceholders[placeholderIndex].SetColliderSize(halfPlaceholderWidth * 2, halfPlaceholderHeight * 2);
    }
}
