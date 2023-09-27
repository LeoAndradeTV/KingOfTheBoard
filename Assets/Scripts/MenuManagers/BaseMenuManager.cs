using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseMenuManager : MonoBehaviour
{
    protected BaseCard currentCard;

    [SerializeField] protected TMP_Text cardName;
    [SerializeField] protected TMP_Text cardDescription;
    [SerializeField] protected Button closeButton;

    /// <summary>
    /// Sets up menu with information of the card that got clicked
    /// </summary>
    /// <param name="card">Card that was clicked</param>
    public virtual void SetUpMenu(BaseCard card)
    {
        currentCard = card;
        CardSO so = currentCard.GetScriptableObject();
        cardName.text = so.cardName;
        cardDescription.text = so.cardDescription;

        SetUpMenuButtons(card);
    }

    /// <summary>
    /// Resets the purchase menu buttons every time the menu pops up
    /// </summary>
    /// <param name="card">Card to be set up</param>
    public virtual void SetUpMenuButtons(BaseCard card)
    {
        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(() => HideMenu());
    }

    public void ShowMenu(BaseCard card)
    {
        SetUpMenu(card);
        gameObject.SetActive(true);
        MouseClick.CanSelect = false;
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
        MouseClick.CanSelect = true;
    }
}
