using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuManager : BaseMenuManager
{
    public static PlayMenuManager Instance { get; private set; }

    [SerializeField] private Button playButton;
    [SerializeField] private Button discardButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        HideMenu();
    }
    /// <summary>
    /// Resets the purchase menu buttons every time the menu pops up
    /// </summary>
    /// <param name="card">Card to be set up</param>
    public override void SetUpMenuButtons(BaseCard card)
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
            HideMenu();
        });
        base.SetUpMenuButtons(card);
    }
}
