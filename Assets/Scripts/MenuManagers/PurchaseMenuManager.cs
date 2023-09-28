using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseMenuManager : IMenuStrategy
{
    private TMP_Text cardPrice;
    private Button purchaseButton;

    public PurchaseMenuManager (BaseMenuManager manager)
    {
        cardPrice = manager.cardPrice;
        purchaseButton = manager.purchaseButton;
    }

    public void SetUpMenu(BaseCard card)
    {
        cardPrice.text = $"Price: {card.GetScriptableObject().cardPrice}";

        purchaseButton.onClick.RemoveAllListeners();
        purchaseButton.onClick.AddListener(() =>
        {
            card.PurchaseCard();
            CardBankManager.Instance.UpdateCardBank();
        });

        ShowSpecificInfo();
    }

    public void ShowSpecificInfo()
    {
        cardPrice.gameObject.SetActive(true);
        purchaseButton.gameObject.SetActive(true);
    }
}
