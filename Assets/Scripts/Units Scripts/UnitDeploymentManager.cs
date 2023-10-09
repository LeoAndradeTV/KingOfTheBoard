using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UnitDeploymentManager : MonoBehaviour
{
    [SerializeField] private Transform deploymentArea;
    [SerializeField] private UnitsPool unitsPool;
    [SerializeField] private UnitMenuManager unitMenuManager;
    [SerializeField] private Button attackButton;

    private List<GameObject> deployedUnits;

    private float minX = -0.475f;
    private float maxX = 0.525f;
    private float xOffset = 0.05f;
    private float minZ = -0.5f;
    private float maxZ = 0.5f;
    private float zOffset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        deployedUnits = new List<GameObject>();
        attackButton.onClick.RemoveAllListeners();
        attackButton.onClick.AddListener(() =>
        {
            CollectUnits(unitMenuManager.GetCurrentSliderValues());
            PlaceUnits();
            unitMenuManager.Hide();
            MouseClick.CanSelect = true;
            Actions.OnUnitsDeployed?.Invoke();
            Actions.OnDiscardCard?.Invoke(unitMenuManager.GetActiveCard());
        });
    }

    public void CollectUnits(Dictionary<UnitType, int> units)
    {
        foreach (KeyValuePair<UnitType, int> pair in units)
        {
            for (int i = 0; i < pair.Value; i++)
            {
                GameObject go = unitsPool.GetPooledUnit(pair.Key);
                deployedUnits.Add(go);
                go.transform.parent = deploymentArea;
            }
        }
    }

    public void PlaceUnits()
    {
        int currentUnit = 0;

        for (float z = minZ; z <= maxZ; z += zOffset)
        {
            for (float x = minX; x <= maxX; x += xOffset)
            {
                if (currentUnit >= deployedUnits.Count)
                    return;

                deployedUnits[currentUnit].transform.localPosition = new Vector3(x, 0, z);
                deployedUnits[currentUnit].SetActive(true);
                currentUnit++;
            }
        }
    }

}
