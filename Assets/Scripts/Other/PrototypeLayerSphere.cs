using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(Rigidbody))]

public class PrototypeLayerSphere : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private MeshFilter _meshFilter;
    private Vector3[] _spawnPointsPositionsColoredBalls;

    public Vector3[] SpawnPointsPositionsColoredBalls => _spawnPointsPositionsColoredBalls;
    public Rigidbody Rigidbody => _rigidbody;

    private void OnEnable()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _rigidbody = GetComponent<Rigidbody>();

        SetSpawnPointsPositionsColoredBalls(_meshFilter.mesh.vertices);
    }

    private void SetSpawnPointsPositionsColoredBalls(Vector3[] spawnPoints)
    {
        _spawnPointsPositionsColoredBalls = spawnPoints.Distinct().ToArray();
    }
}
