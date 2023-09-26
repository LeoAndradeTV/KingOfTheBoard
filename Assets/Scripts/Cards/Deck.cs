using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<BaseCard> possibleCards = new List<BaseCard>();
    [SerializeField] private Button drawButton;
    [SerializeField] private Button shuffleButton;

    private List<BaseCard> deckOfCards = new List<BaseCard>();
    private List<BaseCard> discardedCards = new List<BaseCard>();

    Dictionary<BaseCard, int> initialCards = new Dictionary<BaseCard, int>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeDictionary();
        InitializeDeck();
        SetDrawAndShuffleButtons();
    }

    /// <summary>
    /// Sets how many of each type of card should start in the deck
    /// </summary>
    private void InitializeDictionary()
    {
        initialCards[possibleCards[0]] = 5;
        initialCards[possibleCards[1]] = 5;
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
    public void DrawCards()
    {
        if (deckOfCards.Count == 0)
            return;

        List<int> emptyLocationsInHand = PlayerHand.Instance.GetEmptyLocations();

        foreach (var location in emptyLocationsInHand)
        {
            BaseCard card = deckOfCards[Random.Range(0, deckOfCards.Count)];
            PlayerHand.Instance.PlaceCardInHand(card, location);
            discardedCards.Add(card);
            deckOfCards.Remove(card);
        }

        SetDrawAndShuffleButtons();
    }

    /// <summary>
    /// Sends discarded cards back to the deck
    /// </summary>
    public void ShuffleCards()
    {
        if (discardedCards.Count == 0) 
            return;

        foreach (var card in discardedCards)
        {
            deckOfCards.Add(card);
        }
        discardedCards.Clear();

        SetDrawAndShuffleButtons();
    }

    private void SetDrawAndShuffleButtons()
    {
        drawButton.gameObject.SetActive(deckOfCards.Count > 0);
        shuffleButton.gameObject.SetActive(deckOfCards.Count == 0);
    }
}
