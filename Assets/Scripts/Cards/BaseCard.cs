using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseCard : MonoBehaviour, IPlayable
{
    [SerializeField] protected CardSO cardScriptableObject;
    [SerializeField] protected TMP_Text cardName;
    [SerializeField] protected TMP_Text cardDescription;
    [SerializeField] protected TMP_Text cardPrice;


    // Start is called before the first frame update
    void Start()
    {
        InitializeCard();
    }

    private void InitializeCard()
    {
        cardName.text = cardScriptableObject.cardName;
        cardDescription.text = cardScriptableObject.cardDescription;
        cardPrice.text = $"Price: {cardScriptableObject.cardPrice}";
    }

    public void OnClick()
    {
        Debug.Log($"Card Name: {cardScriptableObject.cardName}, Card Description: {cardScriptableObject.cardDescription}, Card Price: {cardScriptableObject.cardPrice}");
    }

    public void OnClose()
    {
        
    }

    public virtual void Play()
    {
        
    }

    private void OnMouseDown()
    {
        OnClick();
    }

}
