using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static Factory Instance = null;
    [SerializeField] private GameObject m_CardMonsterPrefab;
    [SerializeField] private GameObject m_CardPlaceholderPrefab;

    private void Start()
    {
        Instance = this;
    }

    public Button_Card GenerateCard(CardFinalData data)
    {
        Button_Card_Monster newCard;
        newCard = Instantiate(m_CardMonsterPrefab, Vector3.zero, Quaternion.identity).GetComponent<Button_Card_Monster>();
        newCard.Initialize(data);

        return newCard;
    }

    public CardPlaceholder GenerateCardPlaceholder(EPileType pile, int indexInPile)
    {
        CardPlaceholder newCardPlaceholder;
        newCardPlaceholder = Instantiate(m_CardPlaceholderPrefab, Vector3.zero, Quaternion.identity).GetComponent<CardPlaceholder>();
        newCardPlaceholder.PileType = pile;
        newCardPlaceholder.IndexInPile = indexInPile;

        return newCardPlaceholder;
    }
}
