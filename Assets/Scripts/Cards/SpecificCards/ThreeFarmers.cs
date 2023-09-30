using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeFarmers : BaseCard
{
    private int harvests = 3;
    private int materialsPerHarvest = 1;

    public override void Play()
    {
        Actions.OnHarvestCardPlayed?.Invoke(harvests, materialsPerHarvest);

    }
}
