using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allgetter : BaseCard
{
    private int harvests = 4;
    private int materialsPerHarvest = 1;

    public override void Play()
    {
        Actions.OnHarvestCardPlayed?.Invoke(harvests, materialsPerHarvest);
    }
}
