using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Actions
{
    public static Action ShouldDrawOneCard;
    public static Action OnCardBought;
    public static Action<BaseCard> OnCardClicked;
    public static Action OnCardDiscarded;
    public static Action<BaseCard> OnDiscardCard;
    public static Action<MaterialType, int> OnMaterialAdded;
    public static Action<MaterialType, int> OnMaterialRemoved;
    public static Action<int, int> OnHarvestCardPlayed; //int = amount of harvests, int = amount of material per harvest
    public static Action OnHarvestUsed;
    public static Action<BuildingData> OnBuildingBuilt;
    public static Action OnBuildingSelected;
    public static Action<bool> OnPlacementStatusChanged;
    public static Action OnUnitsDeployed;
    public static Action<BaseCard> OnAttackCardPlayed;
}
