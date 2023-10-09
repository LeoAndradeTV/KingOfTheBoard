using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Data", menuName = "Unit Data")]
public class UnitDataSO : ScriptableObject
{
    public GameObject prefab;
    public UnitType type;
    public int damage;
    public float timeToDisappear;
}
