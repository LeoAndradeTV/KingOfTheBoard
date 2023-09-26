using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseCard : MonoBehaviour, IPlayable
{
    [SerializeField] private CardSO cardScriptableObject;

    [SerializeField] private TMP_Text cardName;
    [SerializeField] private TMP_Text cardDescription;
    [SerializeField] private TMP_Text cardPrice;

    private CardType cardType;


    // Start is called before the first frame update
    void OnEnable()
    {
        InitializeCard();
    }

    private void InitializeCard()
    {
        cardName.text = cardScriptableObject.cardName;
        cardDescription.text = cardScriptableObject.cardDescription;
        cardPrice.text = $"Price: {cardScriptableObject.cardPrice}";
        cardType = cardScriptableObject.cardType;
        if (cardType == CardType.Bought)
        {
            cardPrice.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        OnClick();
    }

    public void OnClick()
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        switch (cardType)
        {
            case CardType.Bought:
                // TODO: Show play menu
                break;
            case CardType.Available:
                PurchaseMenuManager.Instance.ShowMenu(this);
                break;
        }
    }

    public void OnClose()
    {
        
    }

    public virtual void Play()
    {
        Debug.Log("Play");
    }

    public virtual void PurchaseCard()
    {
        
    }

    public CardSO GetScriptableObject()
    {
        return cardScriptableObject;
    }
}
