using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<BaseCard> possibleCards = new List<BaseCard>();

    private List<BaseCard> deckOfCards = new List<BaseCard>();
    private List<BaseCard> discardedCards = new List<BaseCard>();

    Dictionary<BaseCard, int> initialCards = new Dictionary<BaseCard, int>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeDictionary();
        InitializeDeck();
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
    }

    private void ShuffleCards()
    {
        if (discardedCards.Count == 0) 
            return;


    }
}
