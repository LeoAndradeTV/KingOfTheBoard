using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HarvestMenuManager : MonoBehaviour
{
    private BaseCard activeCard;

    [SerializeField] private Button woodButton;
    [SerializeField] private Button rockButton;
    [SerializeField] private Button stringButton;
    [SerializeField] private Button ironButton;
    [SerializeField] private TMP_Text harvestsRemainingText;
    
    private int harvestsRemaining;
    private int materialsPerHarvest;

    public int HarvestsRemaining
    {
        get { return harvestsRemaining; }
        set 
        { 
            harvestsRemaining = value;
            harvestsRemainingText.text = $"Harvests Remaining: {harvestsRemaining}";
        }
    }

    private void Awake()
    {
        Actions.OnCardClicked += SetActiveCard;
        Actions.OnHarvestCardPlayed += SetHarvests;
        Actions.OnHarvestUsed += RemoveOneHarvest;
        HideMenu();
    }

    private void OnDestroy()
    {
        Actions.OnCardClicked -= SetActiveCard;
        Actions.OnHarvestCardPlayed -= SetHarvests;
    }

    private void OnEnable()
    {
        woodButton.onClick.AddListener(() =>
        {
            SetButtonBehavior(MaterialType.Wood, materialsPerHarvest);
        });
        rockButton.onClick.AddListener(() =>
        {
            SetButtonBehavior(MaterialType.Rock, materialsPerHarvest);

        });
        stringButton.onClick.AddListener(() =>
        {
            SetButtonBehavior(MaterialType.String, materialsPerHarvest);

        });
        ironButton.onClick.AddListener(() =>
        {
            SetButtonBehavior(MaterialType.Iron, materialsPerHarvest);
        });
    }

    private void OnDisable()
    {
        woodButton.onClick.RemoveAllListeners();
        rockButton.onClick.RemoveAllListeners();
        stringButton.onClick.RemoveAllListeners();
        ironButton.onClick.RemoveAllListeners();
    }

    private void SetButtonBehavior(MaterialType materialType, int materialAmount)
    {
        Actions.OnMaterialAdded?.Invoke(materialType, materialAmount);
        RemoveOneHarvest();
    }

    private void SetActiveCard(BaseCard card)
    {
        activeCard = card;
    }

    public void SetHarvests(int amount, int materialsPerHarvest)
    {
        HarvestsRemaining = amount;
        this.materialsPerHarvest = materialsPerHarvest;
        ShowMenu();
    }
    private void RemoveOneHarvest()
    {
        HarvestsRemaining--;
        if (HarvestsRemaining <= 0)
        {
            Actions.OnDiscardCard?.Invoke(activeCard);
            HarvestsRemaining = 0;
            HideMenu();
        }
    }

    private void ShowMenu()
    {
        gameObject.SetActive(true);
    }

    private void HideMenu()
    {
        gameObject.SetActive(false);
    }
}
