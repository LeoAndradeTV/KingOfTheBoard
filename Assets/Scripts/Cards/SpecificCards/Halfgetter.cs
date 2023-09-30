using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halfgetter : BaseCard
{
    private int harvests = 2;
    private int materialsPerHarvest = 2;

    public override void Play()
    {
        Actions.OnHarvestCardPlayed?.Invoke(harvests, materialsPerHarvest);
    }
}
