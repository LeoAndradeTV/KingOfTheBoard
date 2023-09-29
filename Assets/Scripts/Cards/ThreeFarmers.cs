using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeFarmers : BaseCard
{
    private int harvests = 3;

    public override void Play()
    {
        Actions.OnFarmerCardPlayed?.Invoke(harvests);
    }

    public override void PurchaseCard()
    {
        Debug.Log("Purchased Three Farmers");
        base.PurchaseCard();
    }
}
