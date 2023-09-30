using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    [SerializeField] private BaseCard[] possibleCards;

    [SerializeField] private Button drawButton;
    [SerializeField] private Button shuffleButton;

    [SerializeField] private PlayerHand hand;

    private List<BaseCard> deckOfCards = new List<BaseCard>();
    private List<BaseCard> discardedCards = new List<BaseCard>();

    Dictionary<BaseCard, int> initialCards = new Dictionary<BaseCard, int>();

    private void OnEnable()
    {
        Actions.OnDiscardCard += DiscardCard;
        Actions.ShouldDrawOneCard += DrawOneCard;
    }

    private void OnDisable()
    {
        Actions.OnDiscardCard -= DiscardCard;
        Actions.ShouldDrawOneCard -= DrawOneCard;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeDictionary();
        InitializeDeck();
        ToggleDrawAndShuffleButtons();
    }

    /// <summary>
    /// Sets how many of each type of card should start in the deck
    /// </summary>
    private void InitializeDictionary()
    {
        for (int i = 0; i < possibleCards.Length; i++)
        {
            int numOfCardsInDeck = possibleCards[i].GetScriptableObject().startingAmountInDeck;
            initialCards[possibleCards[i]] = numOfCardsInDeck;
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
    public void DrawFullHand()
    {
        List<Transform> emptyLocationsInHand = hand.GetEmptyLocations();

        foreach (var location in emptyLocationsInHand)
        {
            if (deckOfCards.Count == 0)
                break;
            
            DrawRandomCard(location);
        }

        ToggleDrawAndShuffleButtons();
    }

    /// <summary>
    /// Draws and places one single card
    /// </summary>
    private void DrawOneCard()
    {
        Transform location = hand.GetEmptyLocations()[0];
        DrawRandomCard(location);
    }

    /// <summary>
    /// Draws a random card and places it in a given location in the player's hand
    /// </summary>
    /// <param name="location">Location in player's hand</param>
    private void DrawRandomCard(Transform location)
    {
        BaseCard card = deckOfCards[Random.Range(0, deckOfCards.Count)];
        hand.PlaceCardInHand(card, location);
        deckOfCards.Remove(card);
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

        ToggleDrawAndShuffleButtons();
    }

    /// <summary>
    /// Activates and deactivates draw and shuffle buttons based on whether player can perform those actions
    /// </summary>
    private void ToggleDrawAndShuffleButtons()
    {
        drawButton.gameObject.SetActive(deckOfCards.Count > 0);
        shuffleButton.gameObject.SetActive(deckOfCards.Count == 0);
    }

    /// <summary>
    /// Sends cards to discard pile
    /// </summary>
    /// <param name="card"></param>
    public void DiscardCard(BaseCard card)
    {
        card.transform.SetParent(transform);
        discardedCards.Add(card);
        TryDrawExtraCard(card);
        card.gameObject.SetActive(false);
        Actions.OnCardDiscarded?.Invoke();
    }

    /// <summary>
    /// Tries to draw an extra card if the card played allows for that
    /// </summary>
    /// <param name="card">Card that was discarded</param>
    private void TryDrawExtraCard(BaseCard card)
    {
        if (card.TryGetComponent(out ICanDrawCard canDraw))
        {
            canDraw.Draw();
        }
    }
}
