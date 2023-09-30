using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronPickaxe : BaseCard
{
    public override void Play()
    {
        Actions.OnMaterialAdded(MaterialType.Iron, 4);
        Actions.OnHarvestUsed?.Invoke();
    }
}
