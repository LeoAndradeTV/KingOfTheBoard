using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text rockText;
    [SerializeField] private TMP_Text stringText;
    [SerializeField] private TMP_Text ironText;

    private int woodAmount;
    private int rockAmount;
    private int stringAmount;
    private int ironAmount;

    public int WoodCounter
    {
        get { return woodAmount; }
        set
        {
            woodAmount = value;
            woodText.text = woodAmount.ToString();
        }
    }

    public int RockCounter
    {
        get { return rockAmount; }
        set
        {
            rockAmount = value;
            rockText.text = rockAmount.ToString();
        }
    }

    public int StringCounter
    {
        get { return stringAmount; }
        set
        {
            stringAmount = value;
            stringText.text = stringAmount.ToString();
        }
    }

    public int IronCounter
    {
        get { return ironAmount; }
        set
        {
            ironAmount = value;
            ironText.text = ironAmount.ToString();
        }
    }
   

    private void OnEnable()
    {
        Actions.OnMaterialAdded += AddMaterial;
        Actions.OnMaterialRemoved += RemoveMaterial;
        Actions.OnBuildingBuilt += RemoveMaterialsFromBuild;
    }

    private void OnDisable()
    {
        Actions.OnMaterialAdded -= AddMaterial;
        Actions.OnMaterialRemoved -= RemoveMaterial;
        Actions.OnBuildingBuilt -= RemoveMaterialsFromBuild;

    }

    public void AddMaterial(MaterialType materialType, int amountToAdd)
    {
        switch (materialType)
        {
            case MaterialType.Wood:
                WoodCounter += amountToAdd;
                break;
            case MaterialType.Rock:
                RockCounter += amountToAdd;
                break;
            case MaterialType.String:
                StringCounter += amountToAdd;
                break;
            case MaterialType.Iron:
                IronCounter += amountToAdd;
                break;
        }
    }

    public void RemoveMaterial(MaterialType materialType, int amountToRemove)
    {
        switch (materialType)
        {
            case MaterialType.Wood:
                WoodCounter -= amountToRemove;
                break;
            case MaterialType.Rock:
                RockCounter -= amountToRemove;
                break;
            case MaterialType.String:
                StringCounter -= amountToRemove;
                break;
            case MaterialType.Iron:
                IronCounter -= amountToRemove;
                break;
        }
    }

    public void RemoveMaterialsFromBuild(BuildingData data)
    {
        WoodCounter -= data.buildingWoodRequirement;
        RockCounter -= data.buildingRockRequirement;
        StringCounter -= data.buildingStringRequirement;
        IronCounter -= data.buildingIronRequirement;
    }
}
