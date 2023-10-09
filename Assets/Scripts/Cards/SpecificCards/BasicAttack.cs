using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : BaseCard
{
    
    public override void Play()
    {
        Actions.OnAttackCardPlayed?.Invoke(this);
        MouseClick.CanSelect = false;
    }
}
