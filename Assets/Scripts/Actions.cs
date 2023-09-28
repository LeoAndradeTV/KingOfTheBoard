using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Actions
{
    public static Action OnCardBought;
    public static Action<BaseCard> OnCardClicked;
    public static Action OnCardDiscarded;
    public static Action<BaseCard> OnDiscardCard;
}
