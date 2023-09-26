using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeFarmers : BaseCard
{
    public override void Play()
    {
        Debug.Log("Played Three Farmers");
    }

    public override void PurchaseCard()
    {
        Debug.Log("Purchased Three Farmers");
        Deck.Instance.AddCardToDeck(this);
        PurchaseMenuManager.Instance.HideMenu();
        CardBankManager.Instance.RemoveCardFromBank(this);
    }
}
