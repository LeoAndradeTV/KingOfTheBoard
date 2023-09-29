using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoFarmers : BaseCard
{
    private int harvests = 2;

    public override void Play()
    {
        Actions.OnFarmerCardPlayed?.Invoke(harvests);
    }
}
