using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class CardBankManager : MonoBehaviour
{
    public static CardBankManager Instance { get; private set; }

    [SerializeField] private Transform[] cardBankLocations;
    [SerializeField] private List<BaseCard> possibleCards = new List<BaseCard>();
    [SerializeField] private List<int> numberOfCards = new List<int>();

    private List<BaseCard> deckOfCards = new List<BaseCard>();
    private Dictionary<BaseCard, int> initialCards = new Dictionary<BaseCard, int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeDictionary();
        InitializeDeck();
        UpdateCardBank();

        Actions.OnCardBought += UpdateCardBank;
    }

    /// <summary>
    /// Sets how many of each type of card should start in the deck
    /// </summary>
    private void InitializeDictionary()
    {
        for (int i = 0; i < possibleCards.Count; i++)
        {
            initialCards[possibleCards[i]] = numberOfCards[i];
        }
    }

    /// <summary>
    /// Creates the deck
    /// </summary>
    private void InitializeDeck()
    {
        foreach (var pair in initialCards)
        {
            for (var i = 0; i < pair.Value; i++)
            {
                BaseCard card = Instantiate(pair.Key, transform);
                card.gameObject.SetActive(false);
                deckOfCards.Add(card);
            }
        }
    }

    /// <summary>
    /// Draws cards based on the amount of empty locations on the board
    /// </summary>
    public void UpdateCardBank()
    {
        if (deckOfCards.Count == 0)
            return;

        List<Transform> emptyLocationsInBank = GetEmptyCardBankLocations();

        foreach (var location in emptyLocationsInBank)
        {
            BaseCard card = deckOfCards[Random.Range(0, deckOfCards.Count)];
            PlaceCardInBank(card, location);
            deckOfCards.Remove(card);
        }

    }

    /// <summary>
    /// Gets Empty locations in card bank
    /// </summary>
    /// <returns></returns>
    private List<Transform> GetEmptyCardBankLocations()
    {
        List<Transform> emptyLocations = new List<Transform>();
        for (int i = 0; i < cardBankLocations.Length; i++)
        {
            if (cardBankLocations[i].childCount == 0)
            {
                emptyLocations.Add(cardBankLocations[i]);
            }
        }
        return emptyLocations;
    }

    /// <summary>
    /// Places a given card in a given location in card bank
    /// </summary>
    /// <param name="card">Card to place.</param>
    /// <param name="locationIndex">Location to place card in.</param>
    private void PlaceCardInBank(BaseCard card, Transform location)
    {
        card.transform.SetParent(location);
        card.transform.position = location.position;
        card.transform.localScale = Vector3.one;
        card.gameObject.SetActive(true);
    }
}
