using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoFarmers : BaseCard
{
    private int harvests = 2;
    private int materialsPerHarvest = 1;

    public override void Play()
    {
        Actions.OnHarvestCardPlayed?.Invoke(harvests, materialsPerHarvest);
    }
}
