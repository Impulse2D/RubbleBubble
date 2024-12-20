using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]

public class PrototypeLayerSphere : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private Vector3[] _spawnPointsPositionsColoredBalls;

    public Vector3[] SpawnPointsPositionsColoredBalls => _spawnPointsPositionsColoredBalls;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();

        SetSpawnPointsPositionsColoredBalls(_meshFilter.mesh.vertices);
    }

    private void SetSpawnPointsPositionsColoredBalls(Vector3[] spawnPoints)
    {
        _spawnPointsPositionsColoredBalls = spawnPoints.Distinct().ToArray();
    }
}
