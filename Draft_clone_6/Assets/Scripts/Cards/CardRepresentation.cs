using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRepresentation
{
    public string Name { get; private set; }
    public Sprite Image { get; private set; }
    public int Attack { get; private set; }
    public int Health { get; private set; }
    public int DiplomacyPoints { get; private set; }
    public int DiplomacyLevel { get; private set; }
    public int Income { get; private set; }
    public ECardAbility Ability { get; private set; }

    public CardRepresentation(CardData data)
    {
        Name = data.Name;
        Image = data.Image;
        Attack = data.Attack;
        Health = data.Health;
        DiplomacyPoints = data.DiplomacyPoints;
        DiplomacyLevel = data.DiplomacyLevel;
        Income = data.Income;
        Ability = data.Ability;
    }

    public CardRepresentation()
    {
        Name = "Italy";
        Attack = 1;
        Health = 1;
        DiplomacyPoints = 0;
        Income = 1;
        DiplomacyLevel = 0;
        DiplomacyPoints = 0;
        Ability = ECardAbility.None;
    }
}
