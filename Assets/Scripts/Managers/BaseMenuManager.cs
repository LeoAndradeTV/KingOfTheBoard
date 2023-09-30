using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseMenuManager : MonoBehaviour
{
    protected BaseCard currentCard;

    [Header("Menus")]
    public GameObject playPurchaseMenu;

    [Header("Elements for every menu")]
    [SerializeField] protected TMP_Text cardName;
    [SerializeField] protected TMP_Text cardDescription;
    [SerializeField] protected Button closeButton;

    [Header("Elements for Play menu")]
    public Button playButton;
    public Button discardButton;

    [Header("Elements for purchase menu")]
    public TMP_Text cardPrice;
    public Button purchaseButton;

    private IMenuStrategy menuStrategy;

    private void Awake()
    {
        HideMenus();
        SetUpCloseButton();
    }


    private void OnEnable()
    {
        Actions.OnCardClicked += ShowMenu;
        Actions.OnCardDiscarded += HideMenus;
    }

    private void OnDisable()
    {
        Actions.OnCardClicked -= ShowMenu;
        Actions.OnCardDiscarded -= HideMenus;
    }

    /// <summary>
    /// Sets up menu with information of the card that got clicked
    /// </summary>
    /// <param name="card">Card that was clicked</param>
    public void SetUpMenu(BaseCard card)
    {
        switch (card.GetCardType())
        {
            case CardType.Bought:
                menuStrategy = new PlayMenuManager(this);
                break;
            case CardType.Available:
                menuStrategy = new PurchaseMenuManager(this);
                break;
        }

        SetUpMenuInformation(card);

        menuStrategy.SetUpMenu(card);
    }

    /// <summary>
    /// Sets the text to reflect the information of a particular card
    /// </summary>
    /// <param name="card">Card to be displayed</param>
    private void SetUpMenuInformation(BaseCard card)
    {
        currentCard = card;
        CardSO so = currentCard.GetScriptableObject();
        cardName.text = so.cardName;
        cardDescription.text = so.cardDescription;
    }

    /// <summary>
    /// Sets up the close menu button
    /// </summary>
    /// <param name="card">Card to be set up</param>
    public void SetUpCloseButton()
    {
        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(() => HideMenus());
    }

    /// <summary>
    /// Sets Up correct menu based on card and shows it
    /// </summary>
    /// <param name="card">Card info to show</param>
    public void ShowMenu(BaseCard card)
    {
        SetUpMenu(card);
        playPurchaseMenu.SetActive(true);
        MouseClick.CanSelect = false;
    }

    /// <summary>
    /// Deactivates all menus
    /// </summary>
    public void HideMenus()
    {
        HideSpecificInfos();
        playPurchaseMenu.gameObject.SetActive(false);
        MouseClick.CanSelect = true;
    }

    /// <summary>
    /// Deactivates components specific to one menu
    /// </summary>
    private void HideSpecificInfos()
    {
        playButton.gameObject.SetActive(false);
        purchaseButton.gameObject.SetActive(false);
        discardButton.gameObject.SetActive(false);
        cardPrice.gameObject.SetActive(false);
    }
}
