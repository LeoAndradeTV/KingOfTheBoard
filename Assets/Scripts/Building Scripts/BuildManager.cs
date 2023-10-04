using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private MaterialManager materialManager;
    [SerializeField] private BuildPlacement buildPlacement;

    [SerializeField] private Button wallButton;
    [SerializeField] private Button archeryButton;
    [SerializeField] private Button knightsButton;
    [SerializeField] private Button siegesButton;
    [SerializeField] private Button bankButton;

    public void Build(BuildingData buildingData)
    {
        if (!PlayerHasEnoughMaterials(buildingData))
        {
            Debug.Log("Not enough materials!");
            return;
        }

        switch (buildingData.buildingType)
        {
            case BuildType.Bank:
                buildPlacement.SelectObject(4, buildingData);
                break;
            case BuildType.Archers:
                buildPlacement.SelectObject(2, buildingData);
                break;
            case BuildType.Knights:
                buildPlacement.SelectObject(3, buildingData);
                break;
            case BuildType.Siege:
                buildPlacement.SelectObject(1, buildingData);
                break;
            case BuildType.Wall:
                buildPlacement.SelectObject(0, buildingData);
                break;
        }
        if (!ChangeCamera.CanMoveCamera)
        {
            Actions.OnBuildingSelected?.Invoke();
        }
        // Hide building menu
        gameObject.SetActive(false);
    }

    private bool PlayerHasEnoughMaterials(BuildingData buildingData)
    {
        bool hasEnough = materialManager.WoodCounter >= buildingData.buildingWoodRequirement && materialManager.RockCounter >= buildingData.buildingRockRequirement && materialManager.StringCounter >= buildingData.buildingStringRequirement && materialManager.IronCounter >= buildingData.buildingIronRequirement;

        return hasEnough;

    }
}
