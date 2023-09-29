using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Actions
{
    public static Action OnCardBought;
    public static Action<BaseCard> OnCardClicked;
    public static Action OnCardDiscarded;
    public static Action<BaseCard> OnDiscardCard;
    public static Action<MaterialType, int> OnMaterialAdded;
    public static Action<MaterialType, int> OnMaterialRemoved;
    public static Action<int> OnFarmerCardPlayed; //int = amount of harvests
}
