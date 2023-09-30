using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance {  get; private set; }

    [SerializeField] private TMP_Text goldAmountText;

    private int goldAmount = 100;
    public int GoldAmount
    {
        get { return goldAmount; }
        set
        {
            goldAmount = value;
            goldAmountText.text = goldAmount.ToString();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        goldAmountText.text = goldAmount.ToString();
    }
}
