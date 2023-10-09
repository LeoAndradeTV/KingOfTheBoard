using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnitsCounter))]
public class UnitMenuManager : MonoBehaviour
{
    private UnitsCounter unitsCounter;

    private BaseCard activeCard;

    [SerializeField] private Slider archersSlider;
    [SerializeField] private Slider knightsSlider;
    [SerializeField] private Slider siegesSlider;

    [SerializeField] private TMP_Text archersAmount;
    [SerializeField] private TMP_Text knightsAmount;
    [SerializeField] private TMP_Text siegesAmount;

    private void Awake()
    {
        gameObject.SetActive(false);
        unitsCounter = GetComponent<UnitsCounter>();
        Actions.OnAttackCardPlayed += Show;
    }

    private void OnDestroy()
    {
        Actions.OnAttackCardPlayed -= Show;
    }

    private void OnEnable()
    {
        SetSlidersMaxValue();
    }

    private void SetSlidersMaxValue()
    {
        archersSlider.maxValue = unitsCounter.ArchersAmount;
        knightsSlider.maxValue = unitsCounter.KnightsAmount;
        siegesSlider.maxValue = unitsCounter.SiegesAmount;
    }

    public Dictionary<UnitType, int> GetCurrentSliderValues()
    {
        Dictionary<UnitType, int> unitsAmount = new Dictionary<UnitType, int>();

        unitsAmount[UnitType.Archer] = (int)archersSlider.value;
        unitsAmount[UnitType.Knight] = (int)knightsSlider.value;
        unitsAmount[UnitType.Siege] = (int)siegesSlider.value;

        return unitsAmount;
    }

    public void OnValueChanged()
    {
        archersAmount.text = archersSlider.value.ToString();
        knightsAmount.text = knightsSlider.value.ToString();
        siegesAmount.text = siegesSlider.value.ToString();
    }

    public void Show(BaseCard card)
    {
        gameObject.SetActive(true);
        activeCard = card;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public BaseCard GetActiveCard()
    {
        return activeCard;
    }
}
