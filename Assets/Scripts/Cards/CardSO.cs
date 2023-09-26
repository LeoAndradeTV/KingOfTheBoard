using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card SO", menuName = "Scriptable Objects/Card")]
public class CardSO : ScriptableObject
{
    public string cardName;
    public string cardDescription;
    public int cardPrice;
    public CardType cardType;
}
