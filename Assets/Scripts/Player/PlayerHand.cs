using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Transform[] cardLocations;
    private List<BaseCard> cardsInHand = new List<BaseCard>();

    /// <summary>
    /// Returns a list of the empty locations in the hand
    /// </summary>
    /// <returns></returns>
    public List<Transform> GetEmptyLocations()
    {
        List<Transform> emptyLocations = new List<Transform>();
        for(int i = 0; i < cardLocations.Length; i++)
        {
            if (cardLocations[i].childCount == 0)
            {
                emptyLocations.Add(cardLocations[i]);
            }
        }
        return emptyLocations;
    }

    /// <summary>
    /// Places a given card in a given location in hand
    /// </summary>
    /// <param name="card">Card to be placed.</param>
    /// <param name="locationIndex">Location in hand.</param>
    public void PlaceCardInHand(BaseCard card, Transform location)
    {
        card.transform.SetParent(location);
        card.transform.position = location.position;
        card.transform.localScale = Vector3.one;
        card.gameObject.SetActive(true);
        cardsInHand.Add(card);
    }
}
