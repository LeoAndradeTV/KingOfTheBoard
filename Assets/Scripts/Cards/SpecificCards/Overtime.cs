using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overtime : BaseCard, ICanDrawCard
{
    private int harvests = 1;
    private int materialsPerHarvest = 1;

    private bool canDraw;

    public override void Play()
    {
        Actions.OnHarvestCardPlayed?.Invoke(harvests, materialsPerHarvest);

        canDraw = true;
    }

    public void Draw()
    {
        if (canDraw)
        {
            Actions.ShouldDrawOneCard?.Invoke();
            canDraw = false;
        }
    }

}
