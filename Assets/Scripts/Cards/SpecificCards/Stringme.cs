using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stringme : BaseCard
{
    public override void Play()
    {
        Actions.OnMaterialAdded(MaterialType.String, 4);
        Actions.OnHarvestUsed?.Invoke();
    }
}
