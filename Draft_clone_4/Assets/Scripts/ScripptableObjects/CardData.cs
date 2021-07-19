using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardData")]
public class CardData : ScriptableObject
{
    public string Name;
    public string ImageLocation;
    public int Attack;
    public int Health;
    public int DiplomacyPoints;
    public int DiplomacyLevel;
    public int Income;
    public ECardAbility Ability;
}
