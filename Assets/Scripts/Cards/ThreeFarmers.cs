using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeFarmers : BaseCard
{
    public override void Play()
    {
        Debug.Log("Played Three Farmers");
        base.Play();
    }

    public override void PurchaseCard()
    {
        Debug.Log("Purchased Three Farmers");
        base.PurchaseCard();
    }
}
