using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFinalData
{
    public string Name;

    public string ImageLocation;

    [SerializeField] public int Attack;

    [SerializeField] public int Health;

    [SerializeField] public int DiplomacyPoints;

    [SerializeField] public int DiplomacyLevel;

    [SerializeField] public int Income;

    [SerializeField] public ECardAbility Ability;

    [SerializeField] public ECardLevel CardLevel;

    public CardFinalData()
    {

    }

    public CardFinalData(CardRepresentation representation, int attack, int health, int diplomacyPoints, int income, ECardAbility ability, ECardLevel cardLevel)
    {
        Name = representation.Name;
        ImageLocation = representation.ImageLocation;
        Attack = attack;
        Health = health;
        DiplomacyPoints = diplomacyPoints;
        DiplomacyLevel = representation.DiplomacyLevel;
        Income = income;
        Ability = ability;
        CardLevel = cardLevel;
    }
}
