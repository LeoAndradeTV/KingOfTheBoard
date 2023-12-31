using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneFarmer : BaseCard
{
    private int harvests = 1;
    private int materialsPerHarvest = 1;

    public override void Play()
    {
        Actions.OnHarvestCardPlayed?.Invoke(harvests, materialsPerHarvest);
    }
}
