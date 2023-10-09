using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsCounter : MonoBehaviour
{
    private int wallsAmount;
    private int banksAmount;
    private int archersAmount = 100;
    private int knightsAmount = 100;
    private int siegesAmount = 100;

    public int WallsAmount
    {
        get { return wallsAmount; }
        private set { wallsAmount = value; }
    }

    public int BanksAmount
    {
        get { return banksAmount; }
        private set { banksAmount = value; }
    }

    public int ArchersAmount
    {
        get { return archersAmount; }
        private set { archersAmount = value; }
    }

    public int KnightsAmount
    {
        get { return knightsAmount; }
        private set { knightsAmount = value; }
    }

    public int SiegesAmount
    {
        get { return siegesAmount; }
        private set { siegesAmount = value; }
    }


    private void OnEnable()
    {
        Actions.OnBuildingBuilt += AddUnits;
    }

    private void OnDisable()
    {
        Actions.OnBuildingBuilt -= AddUnits;
    }

    private void AddUnits(BuildingData data)
    {
        BuildType buildType = data.buildingType;
        switch (buildType)
        {
            case BuildType.Wall:
                WallsAmount += data.unitsPerBuild;
                break;
            case BuildType.Bank:
                BanksAmount += data.unitsPerBuild;
                break;
            case BuildType.Archers:
                ArchersAmount += data.unitsPerBuild;
                break;
            case BuildType.Knights:
                KnightsAmount += data.unitsPerBuild;
                break;
            case BuildType.Siege:
                SiegesAmount += data.unitsPerBuild;
                break;
        }
    }

    private void RemoveUnits(BuildingData data)
    {
        BuildType buildType = data.buildingType;
        switch (buildType)
        {
            case BuildType.Wall:
                WallsAmount -= data.unitsPerBuild;
                break;
            case BuildType.Bank:
                BanksAmount -= data.unitsPerBuild;
                break;
            case BuildType.Archers:
                ArchersAmount -= data.unitsPerBuild;
                break;
            case BuildType.Knights:
                KnightsAmount -= data.unitsPerBuild;
                break;
            case BuildType.Siege:
                SiegesAmount -= data.unitsPerBuild;
                break;
        }
    }
}
