using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(NavMeshSurface))]
public class UpdateNavMeshBake : MonoBehaviour
{
    private NavMeshSurface _meshSurface;

    private void Awake()
    {
        _meshSurface = GetComponent<NavMeshSurface>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        Actions.OnBuildingBuilt += BakeNavMesh;
        _meshSurface.BuildNavMesh();
    }

    private void OnDisable()
    {
        Actions.OnBuildingBuilt -= BakeNavMesh;
    }

    private void BakeNavMesh(BuildingData data)
    {
        _meshSurface.BuildNavMesh();
    }
}
