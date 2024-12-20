using System;
using UnityEngine;

public class SpawnerLayersSpheres : Spawner<LayerSpherePool>
{
    [SerializeField] private SpawnPointFirstLayerSphere _pointPosition;
    [SerializeField] private LayersSpheresDisabler _disablerInterlayers;

    private int _maxQuantityInterlayers;

    public event Action<int> InterlayerInitialized;
    public event Action<LayerSphere> InterlayerReleased;

    private void Start()
    {
        _maxQuantityInterlayers = 2;

        for (int i = 0; i < _maxQuantityInterlayers; i++)
        {
            Create();
        }

        InterlayerInitialized?.Invoke(_maxQuantityInterlayers);
    }

    private void OnEnable()
    {
        _disablerInterlayers.InterlayerDisabled += Create;
    }

    private void OnDisable()
    {
        _disablerInterlayers.InterlayerDisabled -= Create;
    }

    public void Create()
    {
        LayerSphere sphereLayer = ObjectsPool.GetObject(_pointPosition.transform.position, Quaternion.identity);

        InterlayerReleased?.Invoke(sphereLayer);
    }
}
