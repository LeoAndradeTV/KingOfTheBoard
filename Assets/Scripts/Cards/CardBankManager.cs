using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBankManager : MonoBehaviour
{
    [SerializeField] private Transform[] cardBankLocations;
    [SerializeField] private List<BaseCard> possibleCards = new List<BaseCard>();
    [SerializeField] private List<int> numberOfCards = new List<int>();

    private List<BaseCard> deckOfCards = new List<BaseCard>();
    private Dictionary<BaseCard, int> initialCards = new Dictionary<BaseCard, int>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeDictionary();
        InitializeDeck();
        UpdateCardBank();
    }

    /// <summary>
    /// Sets how many of each type of card should start in the deck
    /// </summary>
    private void InitializeDictionary()
    {
        initialCards[possibleCards[0]] = numberOfCards[0];
        initialCards[possibleCards[1]] = numberOfCards[1];
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
                deckOfCards.Add(pair.Key);
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

        List<int> emptyLocationsInBank = GetEmptyCardBankLocations();

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
    private List<int> GetEmptyCardBankLocations()
    {
        List<int> emptyLocations = new List<int>();
        for (int i = 0; i < cardBankLocations.Length; i++)
        {
            if (cardBankLocations[i].childCount == 0)
            {
                emptyLocations.Add(i);
            }
        }
        return emptyLocations;
    }

    /// <summary>
    /// Places a given card in a given location in card bank
    /// </summary>
    /// <param name="card">Card to place.</param>
    /// <param name="locationIndex">Location to place card in.</param>
    private void PlaceCardInBank(BaseCard card, int locationIndex)
    {
        Instantiate(card, cardBankLocations[locationIndex]);
    }
}
