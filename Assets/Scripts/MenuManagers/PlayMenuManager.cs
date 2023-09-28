using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuManager : IMenuStrategy
{
    private Button playButton;
    private Button discardButton;

    public PlayMenuManager(BaseMenuManager manager) 
    {
        playButton = manager.playButton;
        discardButton = manager.discardButton;
    }
    /// <summary>
    /// Resets the purchase menu buttons every time the menu pops up
    /// </summary>
    /// <param name="card">Card to be set up</param>
    public void SetUpMenu(BaseCard card)
    {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() =>
        {
            card.Play();
        });

        discardButton.onClick.RemoveAllListeners();
        discardButton.onClick.AddListener(() =>
        {
            Deck.Instance.DiscardCard(card);
        });
        ShowSpecificInfo();
    }

    public void ShowSpecificInfo()
    {
        playButton.gameObject.SetActive(true);
        discardButton.gameObject.SetActive(true);
    }
}
