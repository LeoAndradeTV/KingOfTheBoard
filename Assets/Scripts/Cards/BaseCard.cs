using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseCard : MonoBehaviour
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

    /// <summary>
    /// Sets up card information when card is placed anywhere on the table
    /// </summary>
    private void InitializeCard()
    {
        cardName.text = cardScriptableObject.cardName;
        cardDescription.text = cardScriptableObject.cardDescription;
        cardPrice.text = $"Price: {cardScriptableObject.cardPrice}";

        // Only show card price if it hasn't been bought yet
        if (cardType == CardType.Bought)
        {
            cardPrice.gameObject.SetActive(false);
        }
    }

    private void OnMouseUp()
    {
        OnClick();
    }

    public void OnClick()
    {
        if (MouseClick.CanSelect)
        {
            Actions.OnCardClicked?.Invoke(this);
        }
    }

    /// <summary>
    /// Applies effect of played card. Should be overriden based on type of card.
    /// </summary>
    public virtual void Play() { }

    /// <summary>
    /// Sends card to discard pile
    /// </summary>
    public virtual void PurchaseCard()
    {
        if (PlayerStats.Instance.GoldAmount > cardScriptableObject.cardPrice)
        {
            PlayerStats.Instance.GoldAmount -= cardScriptableObject.cardPrice;
            cardType = CardType.Bought;
            Actions.OnDiscardCard?.Invoke(this);
        }
    }

    /// <summary>
    /// Gets the card's Scriptable Object
    /// </summary>
    /// <returns></returns>
    public CardSO GetScriptableObject()
    {
        return cardScriptableObject;
    }

    /// <summary>
    /// Gets the card type
    /// </summary>
    /// <returns></returns>
    public CardType GetCardType()
    {
        return cardType;
    }
}
