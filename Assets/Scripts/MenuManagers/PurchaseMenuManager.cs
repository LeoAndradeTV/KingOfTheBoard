using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseMenuManager : MonoBehaviour
{
    public static PurchaseMenuManager Instance { get; private set; }

    private BaseCard currentCard;

    [SerializeField] private TMP_Text cardName;
    [SerializeField] private TMP_Text cardDescription;
    [SerializeField] private TMP_Text cardPrice;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        HideMenu();
    }

    public void SetUpMenu(BaseCard card)
    {
        currentCard = card;
        CardSO so = currentCard.GetScriptableObject();
        cardName.text = so.name;
        cardDescription.text = so.cardDescription;
        cardPrice.text = $"Price: {so.cardPrice}";

        purchaseButton.onClick.AddListener(() => card.PurchaseCard());
        closeButton.onClick.AddListener(() => HideMenu());
    }

    public void ShowMenu(BaseCard card)
    {
        SetUpMenu(card);
        gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
    }
}
