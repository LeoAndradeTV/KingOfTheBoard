using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public static Deck Instance { get; private set; }

    [SerializeField] private List<BaseCard> possibleCards = new List<BaseCard>();
    [SerializeField] private List<int> numberOfCards = new List<int>();

    [SerializeField] private Button drawButton;
    [SerializeField] private Button shuffleButton;

    private List<BaseCard> deckOfCards = new List<BaseCard>();
    private List<BaseCard> discardedCards = new List<BaseCard>();

    Dictionary<BaseCard, int> initialCards = new Dictionary<BaseCard, int>();

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
        SetDrawAndShuffleButtons();
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
    public void DrawCards()
    {
        List<Transform> emptyLocationsInHand = PlayerHand.Instance.GetEmptyLocations();

        foreach (var location in emptyLocationsInHand)
        {
            if (deckOfCards.Count == 0)
                break;

            BaseCard card = deckOfCards[Random.Range(0, deckOfCards.Count)];
            card.transform.SetParent(location);
            card.transform.position = location.position;
            card.transform.localScale = Vector3.one;
            card.gameObject.SetActive(true);
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

    public void DiscardCard(BaseCard card)
    {
        card.transform.SetParent(transform);
        discardedCards.Add(card);
        card.gameObject.SetActive(false);
    }
}
