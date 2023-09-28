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

    /// <summary>
    /// Sets up menu based on the card.
    /// </summary>
    /// <param name="card">Card from which information is drawn.</param>
    public void SetUpMenu(BaseCard card)
    {
        cardPrice.text = $"Price: {card.GetScriptableObject().cardPrice}";

        purchaseButton.onClick.RemoveAllListeners();
        purchaseButton.onClick.AddListener(() =>
        {
            card.PurchaseCard();
            Actions.OnCardBought?.Invoke();
        });

        ShowSpecificInfo();
    }

    /// <summary>
    /// Shows information specific to this type of Menu
    /// </summary>
    public void ShowSpecificInfo()
    {
        cardPrice.gameObject.SetActive(true);
        purchaseButton.gameObject.SetActive(true);
    }
}
