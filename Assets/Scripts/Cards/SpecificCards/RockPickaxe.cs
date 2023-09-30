using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPickaxe : BaseCard
{
    public override void Play()
    {
        Actions.OnMaterialAdded(MaterialType.Rock, 4);
        Actions.OnHarvestUsed?.Invoke();
    }
}
