using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UnitsPool : MonoBehaviour
{
    [SerializeField] private UnitDataSO[] deployableUnits;

    private int maxAmount = 100;
    private List<Unit> unitsList;

    private void Start()
    {
        unitsList = new List<Unit>();
        foreach (UnitDataSO unit in deployableUnits)
        {
            for (int i = 0; i < maxAmount; i++)
            {
                GameObject go = Instantiate(unit.prefab, transform);
                unitsList.Add(go.GetComponent<Unit>());
                go.SetActive(false);
            }
        }
    }

    public GameObject GetPooledUnit(UnitType type)
    {
        foreach (Unit unit in unitsList)
        {
            if (unit.GetUnitType().Equals(type))
            {
                unitsList.Remove(unit);
                return unit.gameObject;
            }
        }
        return null;
    }
}
