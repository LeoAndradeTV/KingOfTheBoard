using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHand : MonoBehaviour
{
    public static PlayerHand Instance;

    [SerializeField] private List<Transform> cardLocations = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Returns a list of the empty locations in the hand
    /// </summary>
    /// <returns></returns>
    public List<int> GetEmptyLocations()
    {
        List<int> emptyLocations = new List<int>();
        for(int i = 0; i < cardLocations.Count; i++)
        {
            if (cardLocations[i].childCount == 0)
            {
                emptyLocations.Add(i);
            }
        }
        return emptyLocations;
    }

    /// <summary>
    /// Places a given card in a given location in hand
    /// </summary>
    /// <param name="card">Card to be placed.</param>
    /// <param name="locationIndex">Location in hand.</param>
    public void PlaceCardInHand(BaseCard card, int locationIndex)
    {
        Instantiate(card, cardLocations[locationIndex]);
    }
}
