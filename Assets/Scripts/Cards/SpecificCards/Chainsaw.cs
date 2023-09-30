using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : BaseCard
{
    public override void Play()
    {
        Actions.OnMaterialAdded?.Invoke(MaterialType.Wood, 4);
        Actions.OnHarvestUsed?.Invoke();
    }
}
