using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseCard : MonoBehaviour, IPlayable
{
    [SerializeField] private CardSO cardScriptableObject;

    [SerializeField] private TMP_Text cardName;
    [SerializeField] private TMP_Text cardDescription;
    [SerializeField] private TMP_Text cardPrice;

    protected CardType cardType;

    // Start is called before the first frame update

    private void Awake()
    {
        cardType = cardScriptableObject.cardType;
    }

    void OnEnable()
    {
        InitializeCard();
    }

    private void InitializeCard()
    {
        cardName.text = cardScriptableObject.cardName;
        cardDescription.text = cardScriptableObject.cardDescription;
        cardPrice.text = $"Price: {cardScriptableObject.cardPrice}";
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
        if (MouseClick.CanSelect)
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        switch (cardType)
        {
            case CardType.Bought:
                PlayMenuManager.Instance.ShowMenu(this);
                break;
            case CardType.Available:
                PurchaseMenuManager.Instance.ShowMenu(this);
                break;
        }
    }

    public void OnClose() { }

    public virtual void Play()
    {
        Debug.Log("Play");
        Deck.Instance.DiscardCard(this);
        PlayMenuManager.Instance.HideMenu();
    }

    public virtual void PurchaseCard()
    {
        cardType = CardType.Bought;
        Deck.Instance.DiscardCard(this);
        PurchaseMenuManager.Instance.HideMenu();
    }

    public CardSO GetScriptableObject()
    {
        return cardScriptableObject;
    }
}
