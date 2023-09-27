using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseMenuManager : BaseMenuManager
{
    public static PurchaseMenuManager Instance { get; private set; }

    [SerializeField] private TMP_Text cardPrice;
    [SerializeField] private Button purchaseButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        HideMenu();
    }

    public override void SetUpMenu(BaseCard card)
    {
        cardPrice.text = $"Price: {card.GetScriptableObject().cardPrice}";
        base.SetUpMenu(card);   
    }

    /// <summary>
    /// Resets the purchase menu buttons every time the menu pops up
    /// </summary>
    /// <param name="card">Card to be set up</param>
    public override void SetUpMenuButtons(BaseCard card)
    {
        purchaseButton.onClick.RemoveAllListeners();
        purchaseButton.onClick.AddListener(() =>
        {
            card.PurchaseCard();
            CardBankManager.Instance.UpdateCardBank();
        });
        base.SetUpMenuButtons(card);
    }
}
